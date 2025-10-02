#include "LT.h"
#include <stdexcept>
#include <cstring>
#include "Error.h"

namespace LT {

    LexTable Create(int size) {
        if (size <= 0) size = LT_MAXSIZE;
        LexTable lt;
        lt.maxsize = size;
        lt.size = 0;
        lt.table = new Entry[size];
        return lt;
    }

    void Add(LexTable& lextable, Entry entry) {
        if (lextable.size >= lextable.maxsize) {
            throw ERROR_THROW(ERROR_LEXTABLE_OVERFLOW);
        }
        lextable.table[lextable.size] = entry;
        lextable.size++;
    }

    Entry GetEntry(LexTable& lextable, int n) {
        if (n < 0 || n >= lextable.size) {
            throw ERROR_THROW(ERROR_LEX_NOT_FOUND);
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

}
