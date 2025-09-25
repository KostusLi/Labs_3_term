#include "stdafx.h"
#include "In.h"
#include "Error.h"
#include <fstream>
#include <sstream>

using namespace std;

string normalizeSpaces(const string& line)
{
    string result;
    bool prevSpace = false;

    for (char c : line)
    {
        if (isspace((unsigned char)c))
        {
            if (!prevSpace)         
            {
                result += ' ';
                prevSpace = true;
            }
        }
        else
        {
            result += c;
            prevSpace = false;
        }
    }

    size_t start = result.find_first_not_of(' ');
    size_t end = result.find_last_not_of(' ');

    if (start == string::npos) return "";
    return result.substr(start, end - start + 1);
}

void addNumeration(unsigned char* text, int&  count, In::IN& in)
{
    string temp = to_string(count);

    for (int i = 0; i < temp.length(); i++) {
        if (temp.length() == 1) text[in.size++] = '0';
        text[in.size++] = temp[i];
    }
    text[in.size++] = ' ';
    count++;
}

namespace In
{
    IN getin(wchar_t infile[])
    {
        IN in;
        in.size = 0; in.lines = 1; in.ignor = 0;
        int col = 1;

        unsigned char* text = new unsigned char[IN_MAX_LEN_TEXT];

        ifstream fin(infile);
        if (!fin.is_open())
            throw ERROR_THROW(110);

        string buffer;
        while (getline(fin, buffer) && in.size<IN_MAX_LEN_TEXT)
        {

            string cleanLine = normalizeSpaces(buffer);
            

            for (size_t i = 0; i < cleanLine.size(); i++)
            {
                unsigned char x = cleanLine[i];
                switch (in.code[x])
                {
                case in.T:
                    text[in.size++] = x;
                    col++;
                    break;
                case in.I:
                    in.ignor++;
                    col++;
                    break;
                case in.F:
                        throw ERROR_THROW_IN(111, in.lines, col);
                        break;
                default:
                    text[in.size++] = in.code[x];
                    col++;
                    break;
                }
            }

            text[in.size++] = '\n';

            in.lines++;
            col = 1;
        }

        text[in.size] = '\0';
        in.text = text;
        return in;
    }
}
