#pragma once
#define ERROR_THROW(id) Error::geterror(id);
#define ERROR_THROW_IN(id, l, c) Error::geterrorin(id, l, c)
#define ERROR_ENTRY(id, m) {id, m, {1, -1}}
#define ERROR_MAXSIZE_MESSAGE 200
#define ERROR_ENTRY_NODEF(id) ERROR_ENTRY(-id, "Неопределённая ошибка")
#define ERROR_ENTRY_NODEF10(id)  ERROR_ENTRY_NODEF(id + 0), ERROR_ENTRY_NODEF(id + 1), ERROR_ENTRY_NODEF(id + 2), ERROR_ENTRY_NODEF(id + 3), \
                                ERROR_ENTRY_NODEF(id + 4), ERROR_ENTRY_NODEF(id + 5), ERROR_ENTRY_NODEF(id + 6), ERROR_ENTRY_NODEF(id + 7), \
                                ERROR_ENTRY_NODEF(id + 8), ERROR_ENTRY_NODEF(id + 9)
#define ERROR_ENTRY_NODEF100(id)  ERROR_ENTRY_NODEF(id + 0), ERROR_ENTRY_NODEF(id + 10), ERROR_ENTRY_NODEF(id + 20), ERROR_ENTRY_NODEF(id + 30), \
                                ERROR_ENTRY_NODEF(id + 40), ERROR_ENTRY_NODEF(id + 50), ERROR_ENTRY_NODEF(id + 60), ERROR_ENTRY_NODEF(id + 70), \
                                ERROR_ENTRY_NODEF(id + 80), ERROR_ENTRY_NODEF(id + 90)
#define ERROR_MAX_ENTRY 1000

// ---- Коды ошибок ----
#define ERROR_SOURCE_OPEN      100   // не удалось открыть исходный файл
#define ERROR_SOURCE_CLOSE     101   // не удалось закрыть исходный файл
#define ERROR_SOURCE_EMPTY     102   // пустой исходный файл
#define ERROR_INCORRECT_SYMBOL 103   // некорректный символ в исходном файле
#define ERROR_IDTABLE_OVERFLOW 200   // переполнение таблицы идентификаторов
#define ERROR_LEXTABLE_OVERFLOW 201  // переполнение таблицы лексем
#define ERROR_ID_NOT_FOUND     202   // идентификатор не найден
#define ERROR_LEX_NOT_FOUND    203   // лексема не найдена
#define ERROR_WRONG_LITERAL    204   // неверный литерал (числовой или строковый)
#define ERROR_WRONG_NUMBER     205   // слишком большое число
#define ERROR_STR_TOOLONG      206   // строковый литерал слишком длинный
#define ERROR_UNEXPECTED_TOKEN 207   // неожиданная лексема
#define ERROR_PARAMS           300   // ошибка в параметрах командной строки
#define ERROR_LOG              301   // ошибка открытия/закрытия log-файла
#define ERROR_OUT              302   // ошибка открытия/закрытия out-файла


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
