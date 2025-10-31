#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>
using namespace std;

void print(const vector<int>& arr)
{
    for (int i : arr)
        cout << i << " ";
    cout << endl;
}

int main()
{
    setlocale(LC_ALL, "ru");
    srand(time(NULL));

    int N;
    cout << "Введите кол-во элементов последовательности: ";
    cin >> N;

    vector<int> nums(N);

    for (int i = 0; i < N; i++)
        nums[i] = rand() % 100;

    cout << "Исходная последовательность:\n";
    print(nums);

    vector<int> dp(N, 1);

    vector<int> prev(N, -1);

    for (int i = 1; i < N; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (nums[i] > nums[j] && dp[i] < dp[j] + 1)
            {
                dp[i] = dp[j] + 1;
                prev[i] = j;
            }
        }
    }

    int maxLen = dp[0];
    int maxIndex = 0;
    for (int i = 1; i < N; i++)
    {
        if (dp[i] > maxLen)
        {
            maxLen = dp[i];
            maxIndex = i;
        }
    }

    vector<int> res;
    for (int i = maxIndex; i != -1; i = prev[i])
        res.push_back(nums[i]);

    reverse(res.begin(), res.end());

    cout << "\nМаксимальная возрастающая подпоследовательность:\n";
    cout << "Длина: " << maxLen << endl;
    print(res);


    return 0;
}
