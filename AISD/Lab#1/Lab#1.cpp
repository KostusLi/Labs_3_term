#include <iostream>
using namespace std;

void hanoi(int N, int i, int k)
{
    if (N == 1) {
        cout << "Переместить диск " << N << " с " << i << " на " << k << endl;
    }
    else {
        int temp = 6 - i - k;
        hanoi(N - 1, i, temp);
        cout << "Переместить диск " << N << " с " << i << " на " << k << endl;
        hanoi(N - 1, temp, k);
    }
}


int main()
{
    while (true)
    {
        setlocale(LC_ALL, "ru");
        int N, k;
        cout << "Введите кол-во дисков N в ханойской башне: ";
        cin >> N;



        cout << "Введите стержень k, на который будем перекладывать диски: ";
        cin >> k;

        hanoi(N, 1, k);
        break;
    }

}
