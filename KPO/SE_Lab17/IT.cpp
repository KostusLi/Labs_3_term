#include "IT.h"
#include "Error.h"
#include <stdexcept>
#include <cstring>

namespace IT {

    IdTable Create(int size) {
        if (size <= 0) size = TI_MAXSIZE;
        IdTable it;
        it.maxsize = size;
        it.size = 0;
        it.table = new Entry[size];
        return it;
    }

    void IT::Add(IdTable& idtable, const Entry& entry) {
        for (int i = 0; i < idtable.size; ++i) {
            if (strncmp(idtable.table[i].id, entry.id, ID_MAXSIZE) == 0) {
                return;
            }
        }

        if (idtable.size >= idtable.maxsize) {
            throw ERROR_THROW(ERROR_IDTABLE_OVERFLOW);
        }

        idtable.table[idtable.size] = entry;
        idtable.size++;
    }

    Entry GetEntry(IdTable& idtable, char id[ID_MAXSIZE]) {
        for (int i = 0; i < idtable.size; ++i) {
            if (strncmp(idtable.table[i].id, id, ID_MAXSIZE) == 0) {
                return idtable.table[i];
            }
        }
        throw ERROR_THROW(ERROR_ID_NOT_FOUND);
    }

    void Delete(IdTable& idtable) {
        if (idtable.table) {
            delete[] idtable.table;
            idtable.table = nullptr;
        }
        idtable.size = 0;
        idtable.maxsize = 0;
    }

}
