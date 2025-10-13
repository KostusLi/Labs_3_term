#pragma once
#define ID_MAXSIZE 12000
#define TI_MAXSIZE 12000
#define TI_INT_DEFAULT 0x00000000
#define TI_STR_DEFAULT 0x00
#define TI_NULLIDX 0xffffffff
#define TI_STR_MAXSIZE 2000
#define MAX_STRING 3000
#define TI_INT_MAXSIZE 2147483646

namespace IT {
    enum IDDATATYPE { INT = 1, STR = 2 };
    enum IDTYPE { V = 1, F = 2, P = 3, L = 3 };

    struct Entry {
        int idxfirstLE;
        char id[ID_MAXSIZE];
        IDDATATYPE iddatatype;
        IDTYPE idtype;

        union {
            int vint;
            struct {
                char len;
                char str[TI_STR_MAXSIZE - 1];
            } vstr;
        } value;

    };

    struct IdTable {
        int maxsize;
        int size;
        Entry* table;
    };

    IdTable Create(int size);
    void Add(IdTable& idtable, const Entry& entry);
    Entry GetEntry(IdTable& idtable, const char id[ID_MAXSIZE]);
    void Delete(IdTable& idtable);
}
