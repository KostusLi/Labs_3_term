#include <iostream>
#include <vector>

using namespace std;

const int INF = 1e9;

pair<vector<vector<int>>, vector<vector<int>>> FloidUorsh(vector<vector<int>> distInit, int vertexCount)
{
    vector<vector<int>> dist = distInit;
    vector<vector<int>> nextVertex(vertexCount, vector<int>(vertexCount, -1));

    for (int i = 0; i < vertexCount; i++)
    {
        for (int j = 0; j < vertexCount; j++) {
            if (dist[i][j] != INF && i != j) {
                nextVertex[i][j] = j;
            }
            else {
                nextVertex[i][j] = -1;
            }
        }
    }

    for (int v = 0; v < vertexCount; v++)
    {
        for (int a = 0; a < vertexCount; a++)
        {
            for (int b = 0; b < vertexCount; b++)
            {
                if (dist[a][v]!=INF && dist[v][b]!=INF && dist[a][b] > dist[a][v] + dist[v][b])
                {
                    dist[a][b] = dist[a][v] + dist[v][b];
                    nextVertex[a][b] = nextVertex[a][v];
                }
            }
        }
    }

    return { dist, nextVertex };
}

vector<int> getPath(vector<vector<int>>& next, int i, int j) {
    if (next[i][j] == -1) return {};
    vector<int> path = { i };
    while (i != j) {
        i = next[i][j];
        path.push_back(i);
    }
    return path;
}


int main()
{
    setlocale(LC_ALL, "ru");

    int vertexCount = 6;

    vector<vector<int>> distInit = {
        {0,   28,   21,   59,  12,  27},   
        {7,   0,  24,  INF,  21,   9},   
        {9,  32,   0,   13,  11,  INF},   
        {8,  INF,  5,   0,  16, INF},   
        {14,  13,  15,  10,   0,   22},   
        {15, 18, INF,  INF, 6,   0}    
    };

    auto result = FloidUorsh(distInit, vertexCount);
    vector<vector<int>> distRes = result.first;
    vector<vector<int>> nextVertex = result.second;

    cout << "Матрица D кратчайших расстояний:\n";
    for (int i = 0; i < vertexCount; i++)
    {
        cout << "Растояние с вершины " << i+1 << " до вершин: ";
        for (int j = 0; j < vertexCount; j++)
        {
            cout << j + 1 << "---" << distRes[i][j] << ", ";
        }
        cout << endl;
    }

    cout << "\nМатрица S коротких путей по вершинам:\n";
    for (int i = 0; i < vertexCount; i++)
    {
        for (int j = 0; j < vertexCount; j++)
        {
            if (nextVertex[i][j] == -1) cout << "0 ";
            else cout << nextVertex[i][j] + 1 << " ";
        }
        cout << endl;
    
    }

    cout << "Путь из вершины 1 в вершину 2: ";
    for (int v : getPath(nextVertex, 0, 1))
    {
        cout << v+1 << " ";
    }

}

