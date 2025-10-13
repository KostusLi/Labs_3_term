#include <iostream>
#include <vector>

using namespace std;

void print(vector<int> arr)
{
    for (int i : arr)
    {
        cout << i << " ";
    }
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
    {
        nums[i] = rand() % 100;
    }

    print(nums);

    int k = 0;
    vector<int> res;

    while (k!=N)
    {
        vector<int> temp;
        int prev = -1;
        for (int i=k; i<N; i++)
        {
            if (nums[i] > prev)
            {
                temp.push_back(nums[i]);
                prev = nums[i];
            }
        }

        if (temp.size() > res.size())
        {
            res = temp;
        }
        k++;
    }

    cout << "\nМаксимальная возрастающая подпоследовательность:\n";
    cout << "Длина нашей последовательности: " << res.size() << endl;
    print(res);

}
