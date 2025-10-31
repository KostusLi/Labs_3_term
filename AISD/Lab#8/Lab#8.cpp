#include <iostream>
#include <vector>
#include <string>
#include <Windows.h>
#include <algorithm>
#define n cout << endl;

using namespace std;

struct Product {
    string name; 
    int weight;
    int cost;  
};

int main()
{
    setlocale(LC_ALL, "ru");
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    int N;
    cout << "Введите максимальный вес рюкзака: ";
    cin >> N;
    n;

    int count;
    cout << "Введите количество товаров: ";
    cin >> count;
    cout << "----------------- Введите товары -----------------" << endl;

    vector<Product> items;
    items.reserve(count);

    for (int i = 0; i < count; i++) {
        Product p;
        cout << "Введите название товара: ";
        cin >> p.name;
        n;
        cout << "Введите вес товара: ";
        cin >> p.weight;
        n;
        cout << "Введите цену товара: ";
        cin >> p.cost;
        n;

        items.push_back(p);
        cout << "======================================" << endl;
    }

    cout << "----------------- Список товаров -----------------" << endl;
    for (int i = 0; i < count; i++) {
        cout << i + 1 << ") " << items[i].name << ": вес - "
            << items[i].weight << " lb, цена - "
            << items[i].cost << " $" << endl;
    }

    vector<vector<int>> dp(count + 1, vector<int>(N + 1, 0));

    for (int i = 1; i <= count; i++) {
        for (int w = 1; w <= N; w++) {
            if (items[i - 1].weight <= w) {
                dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - items[i - 1].weight] + items[i - 1].cost);
            }
            else {
                dp[i][w] = dp[i - 1][w];
            }
        }
    }

    cout << endl << "Максимальная стоимость, которую можно унести: "
        << dp[count][N] << " $" << endl;

    cout << endl << "----------------- Выбранные товары -----------------" << endl;
    int w = N;
    for (int i = count; i > 0 && w > 0; i--) {
        if (dp[i][w] != dp[i - 1][w]) {
            cout << "- " << items[i - 1].name
                << " (вес: " << items[i - 1].weight
                << "lb, цена: " << items[i - 1].cost << "$)" << endl;
            w -= items[i - 1].weight;
        }
    }

    return 0;
}
