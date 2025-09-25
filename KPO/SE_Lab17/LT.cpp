// LT.cpp
#include "LT.h"
#include <stdexcept>
#include <cstring> // для memcpy если нужно

namespace LT {

    LexTable Create(int size) {
        if (size <= 0) size = LT_MAXSIZE;
        LexTable lt;
        lt.maxsize = size;
        lt.size = 0;
        lt.table = new Entry[size];
        // (не нужно инициализировать таблицу дальше)
        return lt;
    }

    void Add(LexTable& lextable, Entry entry) {
        if (lextable.size >= lextable.maxsize) {
            throw std::overflow_error("LT::Add - lex table overflow");
        }
        // копируем запись в таблицу
        lextable.table[lextable.size] = entry;
        lextable.size++;
    }

    Entry GetEntry(LexTable& lextable, int n) {
        if (n < 0 || n >= lextable.size) {
            throw std::out_of_range("LT::GetEntry - index out of range");
        }
        return lextable.table[n];
    }

    void Delete(LexTable& lextable) {
        if (lextable.table) {
            delete[] lextable.table;
            lextable.table = nullptr;
        }
        lextable.size = 0;
        lextable.maxsize = 0;
    }

} // namespace LT
