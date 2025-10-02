#include <iostream>
using namespace std;

const int N = 8;

int graph[N][N] =
{
	{0, 2, 0, 8, 2, 0, 0, 0},
	{2, 0, 3, 10, 5, 0, 0, 0},
	{0, 3, 0, 0, 12, 0, 0, 7},
	{8, 10, 0, 0, 14, 3, 1, 0},
	{2, 5, 12, 14, 0, 11, 4, 8},
	{0, 0, 0, 3, 11, 0, 6, 0},
	{0, 0, 0, 1, 4, 6, 0, 9},
	{0, 0, 7, 0, 8, 0, 9, 0}
};


void SolvePrima()
{

	int edgeCount = 0;
	bool visited[N];

	for (int i = 0; i < N; i++)
	{
		visited[i] = false;
	}

	int num = 1;

	visited[num - 1] = true;

	while (edgeCount < N - 1)
	{
		int min = INT_MAX;
		int a = -1, b = -1;

		for (int i = 0; i < N; i++)
		{
			if (visited[i])
			{
				for (int j = 0; j < N; j++)
				{
					if (!visited[j] && graph[i][j] > 0)
					{
						if (min > graph[i][j])
						{
							min = graph[i][j];
							a = i;
							b = j;
						}
					}
				}
			}
		}

		if (a != -1 && b != -1)
		{
			cout << a + 1 << " -> " << b + 1 << " = " << graph[a][b] << '\n';
			visited[b] = true;
			edgeCount++;
		}
	}
}



void SolveKruskal()
{
	int edgeCount = 0;
	int parent[N];

	for (int i = 0; i < N; i++)
	{
		parent[i] = i;
	}

	while (edgeCount < N - 1)
	{
		int min = INT_MAX;
		int a = -1, b = -1;

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				int rootI = i;

				while (parent[rootI] != rootI)
				{
					rootI = parent[rootI];
				}

				int rootJ = j;
				while (parent[rootJ] != rootJ)
				{
					rootJ = parent[rootJ];
				}

				if (rootI != rootJ && graph[i][j] < min && graph[i][j] != 0)
				{
					min = graph[i][j];
					a = i;
					b = j;
				}
			}
		}

		if (a != -1 && b != -1)
		{
			int rootA = a;
			while (parent[rootA] != rootA)
			{
				rootA = parent[rootA];
			}

			int rootB = b;
			while (parent[rootB] != rootB)
			{
				rootB = parent[rootB];
			}

			cout << a + 1 << " -> " << b + 1 << " = " << graph[a][b] << '\n';
			parent[rootA] = rootB;
			edgeCount++;
		}
	}
}
 

int main()
{
	setlocale(LC_CTYPE, "rus");

	cout << "Алгоритм Прима:\n";
	SolvePrima();

	cout << "\nАлгоритм Краскала:\n";
	SolveKruskal();


	return 0;
}