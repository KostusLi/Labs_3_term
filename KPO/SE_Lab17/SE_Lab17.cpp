#include "stdafx.h"
#include <iostream>
#include <locale>
#include <cwchar>
#include <iomanip>
#include <sstream>
#include <string>

#include "Error.h"
#include "Parm.h"
#include "Log.h"
#include "In.h"
#include "Out.h"
#include "LT.h"
#include "IT.h"

using namespace std;


void Analyze(In::IN in, LT::LexTable& lt, IT::IdTable& it) {
    std::string source(reinterpret_cast<char*>(in.text), in.size);
    int line = 1;

    for (size_t i = 0; i < source.size(); ) {
        char c = source[i];

        // --- перевод строки ---
        if (c == '\n') {
            line++;
            i++;
            continue;
        }

        // --- пропуск пробелов и табов ---
        if (isspace((unsigned char)c)) {
            i++;
            continue;
        }

        LT::Entry lex{};
        lex.sn = line;
        lex.idxTI = LT_TI_NULLIDX;

        // --- идентификатор или ключевое слово ---
        if (isalpha((unsigned char)c)) {
            std::string word;
            while (i < source.size() && (isalnum((unsigned char)source[i]) || source[i] == '_')) {
                word += source[i++];
            }

            // ключевые слова
            if (word == "integer")      lex.lexema[0] = LEX_INTEGER;
            else if (word == "string")  lex.lexema[0] = LEX_STRING;
            else if (word == "function")lex.lexema[0] = LEX_FUNCTION;
            else if (word == "declare") lex.lexema[0] = LEX_DECLARE;
            else if (word == "return")  lex.lexema[0] = LEX_RETURN;
            else if (word == "print")   lex.lexema[0] = LEX_PRINT;
            else if (word == "main")    lex.lexema[0] = LEX_MAIN;
            else {
                // это идентификатор
                lex.lexema[0] = LEX_ID;

                IT::Entry idEntry{};
                strncpy_s(idEntry.id, word.c_str(), ID_MAXSIZE - 1);
                idEntry.id[ID_MAXSIZE - 1] = '\0';
                idEntry.iddatatype = IT::INT; // по умолчанию
                idEntry.idtype = IT::V;       // переменная
                idEntry.idxfirstLE = lt.size;

                IT::Add(it, idEntry);
                lex.idxTI = it.size - 1;
            }
        }

        // --- число ---
        else if (isdigit((unsigned char)c)) {
            std::string num;
            while (i < source.size() && isdigit((unsigned char)source[i])) {
                num += source[i++];
            }
            lex.lexema[0] = LEX_LITERAL;

            IT::Entry lit{};
            strncpy_s(lit.id, num.c_str(), ID_MAXSIZE - 1);
            lit.iddatatype = IT::INT;
            lit.idtype = IT::L;
            lit.value.vint = std::stoi(num);
            lit.idxfirstLE = lt.size;
            IT::Add(it, lit);
            lex.idxTI = it.size - 1;
        }

        // --- строковый литерал ---
        else if (c == '\'') {
            i++; // пропускаем '
            std::string str;
            while (i < source.size() && source[i] != '\'') {
                str += source[i++];
            }
            if (i < source.size() && source[i] == '\'') i++; // закрывающая '

            lex.lexema[0] = LEX_LITERAL;

            IT::Entry lit{};
            lit.iddatatype = IT::STR;
            lit.idtype = IT::L;
            lit.value.vstr.len = (char)std::min((int)str.size(), TI_STR_MAXSIZE - 1);
            strncpy_s(lit.value.vstr.str, str.c_str(), lit.value.vstr.len);
            lit.value.vstr.str[lit.value.vstr.len] = '\0';
            strncpy_s(lit.id, str.c_str(), ID_MAXSIZE - 1);
            lit.idxfirstLE = lt.size;
            IT::Add(it, lit);
            lex.idxTI = it.size - 1;
        }

        // --- одиночные символы (операторы и разделители) ---
        else {
            switch (c) {
            case '=': lex.lexema[0] = '='; break;
            case '+': lex.lexema[0] = LEX_PLUS; break;
            case '-': lex.lexema[0] = LEX_MINUS; break;
            case '*': lex.lexema[0] = LEX_STAR; break;
            case '/': lex.lexema[0] = LEX_DIRSLASH; break;
            case ';': lex.lexema[0] = ';'; break;
            case ',': lex.lexema[0] = ','; break;
            case '{': lex.lexema[0] = '{'; break;
            case '}': lex.lexema[0] = '}'; break;
            case '(': lex.lexema[0] = '('; break;
            case ')': lex.lexema[0] = ')'; break;
            default:
                throw ERROR_THROW_IN(111, line, (int)(i + 1));
            }
            i++;
        }

        // добавляем в таблицу лексем
        LT::Add(lt, lex);
    }
}



int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "russian");


    cout << "--------- тест geterror ---------\n\n";
    try { throw ERROR_THROW(100); }
    catch (Error::ERROR e)

    {
        cout << "Ошибка " << e.id << ": " << e.message << "\n\n";
    };


    cout << "--------- тест geterrorin ---------\n\n";
    try { throw ERROR_THROW_IN(111, 7, 7); }
    catch (Error::ERROR e)
    {
        cout << "Ошибка " << e.id << ": " << e.message << ", строка " << e.inext.line << ", позиция " << e.inext.col << " \n\n";
    };


    cout << "--------- тест getparm ---------\n\n";
    try {
        Parm::PARM parm = Parm::getparm(argc, argv);
        wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << "\n\n";
    }
    catch (Error::ERROR e)
    {
        cout << "Ошибка " << e.id << ": " << e.message << "\n\n";
    }

    cout << "--------- getin ----------\n\n";
    try
    {
        Parm::PARM parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);
        cout << in.text << endl;
        cout << "Всего символов: " << in.size << endl;
        cout << "Всего строк: " << in.lines << endl;
        cout << "Пропущено: " << in.ignor << endl;
    }
    catch (Error::ERROR e)
    {
        cout << "Ошибка " << e.id << ": " << e.message << endl;
        cout << "Строка " << e.inext.line << " позиция " << e.inext.col << "\n\n";
    }

    Log::LOG log = Log::INITLOG;

    try
    {
        Parm::PARM parm = Parm::getparm(argc, argv);
        log = Log::getlog(parm.log);
        Log::WriteLine(log, (char*)"Тест", (char*)" без ошибок \n", "");
        Log::WriteLine(log, (wchar_t*)L"Тест", (wchar_t*)L" без ошибок \n", L"");
        Log::WriteLog(log);
        Log::WriteParm(log, parm);
        In::IN in = In::getin(parm.in);
        Log::WriteIn(log, in);
        Log::Close(log);
    }
    catch (Error::ERROR e)
    {
        Log::WriteError(log, e);
    };

    Out::OUT out = Out::INITOUT;

    try {
        Parm::PARM parm = Parm::getparm(argc, argv);
        out = Out::getout(parm.out);
        In::IN in = In::getin(parm.in);
        Out::WriteInOut(out, in);
    }
    catch (Error::ERROR e)
    {
        Out::WriteErrorOut(out, e);
    };


    try {
        Parm::PARM parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);

        LT::LexTable lexTable = LT::Create(LT_MAXSIZE);
        IT::IdTable idTable = IT::Create(TI_MAXSIZE);

        Analyze(in, lexTable, idTable);

        // вывод таблицы лексем
        cout << "ТАБЛИЦА ЛЕКСЕМ:\n";
        int currentLine = -1;
        for (int i = 0; i < lexTable.size; i++) {
            LT::Entry e = LT::GetEntry(lexTable, i);

            // если новая строка — начинаем с номера строки
            if (e.sn != currentLine) {
                if (currentLine != -1) cout << "\n"; // перенос после предыдущей строки
                cout << std::setw(2) << std::setfill('0') << e.sn << " ";
                currentLine = e.sn;
            }

            // выводим лексему
            cout << e.lexema[0];
        }
        cout << "\n";


        // вывод таблицы идентификаторов
        cout << "\nТАБЛИЦА ИДЕНТИФИКАТОРОВ:\n";
        for (int i = 0; i < idTable.size; i++) {
            IT::Entry e = idTable.table[i];
            cout << i << ") " << e.id
                << " type=" << (e.iddatatype == IT::INT ? "int" : "string")
                << " firstLE=" << e.idxfirstLE << "\n";
        }

        // очистка
        LT::Delete(lexTable);
        IT::Delete(idTable);
        delete[] in.text; // освобождаем память
    }
    catch (Error::ERROR e) {
        cout << "Ошибка " << e.id << ": " << e.message
            << " строка " << e.inext.line
            << " позиция " << e.inext.col << endl;
    }
    catch (std::exception& ex) {
        cerr << "Ошибка: " << ex.what() << endl;
    }


    cout << "-------------------------------------------------------------------------" << endl;
    system("pause");

    return 0;
}