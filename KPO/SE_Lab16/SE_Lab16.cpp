#include <iostream>
#include "FST.h"
#include <tchar.h>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "ru");

    FST::FST fst1(
        (char*)"aaabbbaba",
        4,
        FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('b', 2)),
        FST::NODE(1, FST::RELATION('a', 3)),
        FST::NODE()
    );

    if (FST::execute(fst1))
        cout << "Цепочка " << fst1.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst1.string << " не распознана" << endl;


    FST::FST fst2(
        (char*)"aaabbbabba",
        4,
        FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('b', 2)),
        FST::NODE(1, FST::RELATION('a', 3)),
        FST::NODE()
    );

    if (FST::execute(fst2))
        cout << "Цепочка " << fst2.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst2.string << " не распознана" << endl;


    FST::FST fst3(
        (char*)"abb",
        4,
        FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('b', 2)),
        FST::NODE(1, FST::RELATION('a', 3)),
        FST::NODE()
    );

    if (FST::execute(fst3))
        cout << "Цепочка " << fst3.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst3.string << " не распознана" << endl;

    
    FST::FST fst4(
        (char*)"abbab",
        4,
        FST::NODE(3, FST::RELATION('b', 0), FST::RELATION('a', 0), FST::RELATION('b', 1)),
        FST::NODE(1, FST::RELATION('a', 2)),
        FST::NODE(1, FST::RELATION('b', 3)),
        FST::NODE()
    );

    if (FST::execute(fst4))
        cout << "Цепочка " << fst4.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst4.string << " не распознана" << endl;


    FST::FST fst5(
        (char*)"abababbbb",
        4,
        FST::NODE(3, FST::RELATION('b', 0), FST::RELATION('a', 0), FST::RELATION('b', 1)),
        FST::NODE(1, FST::RELATION('b', 2)),
        FST::NODE(1, FST::RELATION('b', 3)),
        FST::NODE()
    );

    if (FST::execute(fst5))
        cout << "Цепочка " << fst5.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst5.string << " не распознана" << endl;


    FST::FST fst6(
        (char*)"abbbbaaaaabb",
        4,
        FST::NODE(3, FST::RELATION('b', 0), FST::RELATION('a', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('b', 2)),
        FST::NODE(1, FST::RELATION('b', 3)),
        FST::NODE()
    );

    if (FST::execute(fst6))
        cout << "Цепочка " << fst6.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst6.string << " не распознана" << endl;


    FST::FST fst7(
        (char*)"abbaaaabaaa",
        4,
        FST::NODE(3, FST::RELATION('b', 0), FST::RELATION('a', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 2)),
        FST::NODE(1, FST::RELATION('a', 3)),
        FST::NODE()
    );

    if (FST::execute(fst7))
        cout << "Цепочка " << fst7.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst7.string << " не распознана" << endl;

    FST::FST fst8(
        (char*)"abbvaaaabaaa",
        4,
        FST::NODE(3, FST::RELATION('b', 0), FST::RELATION('a', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 2)),
        FST::NODE(1, FST::RELATION('a', 3)),
        FST::NODE()
    );

    if (FST::execute(fst8))
        cout << "Цепочка " << fst8.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst8.string << " не распознана" << endl;


    FST::FST fst9(
        (char*)"abbaaaabaaa",
        4,
        FST::NODE(3, FST::RELATION('b', 0), FST::RELATION('a', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 2)),
        FST::NODE(1, FST::RELATION('a', 3)),
        FST::NODE()
    );

    if (FST::execute(fst9))
        cout << "Цепочка " << fst9.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst9.string << " не распознана" << endl;


    system("pause");
    return 0;
}
