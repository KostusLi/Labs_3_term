#pragma once
#define ERROR_THROW(id) Error::geterror(id)
#define ERROR_THROW_IN(id, l, c) Error::geterrorin(id, l, c)
#define ERROR_ENTRY(id, m) {id, m, {1, -1}}
#define ERROR_MAXSIZE_MESSAGE 200
#define ERROR_ENTRY_NODEF(id) ERROR_ENTRY(id, "Неопределённая ошибка")
#define ERROR_ENTRY_NODEF10(id)  ERROR_ENTRY_NODEF(id + 0), ERROR_ENTRY_NODEF(id + 1), ERROR_ENTRY_NODEF(id + 2), ERROR_ENTRY_NODEF(id + 3), \
                                ERROR_ENTRY_NODEF(id + 4), ERROR_ENTRY_NODEF(id + 5), ERROR_ENTRY_NODEF(id + 6), ERROR_ENTRY_NODEF(id + 7), \
                                ERROR_ENTRY_NODEF(id + 8), ERROR_ENTRY_NODEF(id + 9)
#define ERROR_ENTRY_NODEF100(id)  ERROR_ENTRY_NODEF(id + 0), ERROR_ENTRY_NODEF(id + 10), ERROR_ENTRY_NODEF(id + 20), ERROR_ENTRY_NODEF(id + 30), \
                                ERROR_ENTRY_NODEF(id + 40), ERROR_ENTRY_NODEF(id + 50), ERROR_ENTRY_NODEF(id + 60), ERROR_ENTRY_NODEF(id + 70), \
                                ERROR_ENTRY_NODEF(id + 80), ERROR_ENTRY_NODEF(id + 90)
#define ERROR_MAX_ENTRY 1000

#define ERROR_SOURCE_EMPTY     102 
#define ERROR_INCORRECT_SYMBOL 103
#define ERROR_IDTABLE_OVERFLOW 200
#define ERROR_LEXTABLE_OVERFLOW 201
#define ERROR_ID_NOT_FOUND     202
#define ERROR_LEX_NOT_FOUND    203
#define ERROR_WRONG_NUMBER     204
#define ERROR_STR_TOOLONG      205


namespace Error
{
    struct ERROR
    {
        int id;
        char message[ERROR_MAXSIZE_MESSAGE];
        struct IN
        {
            short line; 
            short col;
        } inext;
    };
    ERROR geterror(int id);
    ERROR geterrorin(int id, int line, int col);
};
