#include <iostream>
#include <vector>

using namespace std;

const int INF = 1e9;

vector<int> fDeikstri(vector<vector<pair<int, int>>> graph, int start)
{
    vector<int> dist(graph.size(), INF);
     
    dist[start] = 0;

    vector<bool> visited(graph.size());

    for (int i = 0; i < graph.size(); i++)
    {
        int nearest = -1;
        for (int v = 0; v < graph.size(); v++)
            if (!visited[v] && (nearest == -1 || dist[nearest] > dist[v]))
                nearest = v;

        visited[nearest] = true;

        for (auto &[to, weight] : graph[nearest])
            if (dist[to] > dist[nearest] + weight)
                dist[to] = dist[nearest] + weight;

    }

    return dist;

}

int main()
{
    setlocale(LC_ALL, "ru");

    vector<vector<pair<int, int>>> graph = {
    { {1, 7}, {2, 10} },            
    { {0, 7}, {5, 9}, {6, 27} },    
    { {0, 10}, {5, 8}, {4, 31} },   
    { {4, 32}, {7, 17}, {8, 21} },  
    { {2, 31}, {3, 32} },           
    { {1, 9}, {2, 8}, {7, 11} },    
    { {1, 27}, {8, 15} },           
    { {5, 11}, {3, 17}, {8, 15} }, 
    { {3, 21}, {7, 15}, {6, 15} }
    };

    int start;
    cout << "Введите стартовую вершину (0-" << graph.size() - 1 << "): ";
    cin >> start;

    if (start < 0 || start >= graph.size()) {
        cout << "Ошибка: такой вершины нет." << endl;
        return 0;
    }

    vector<int> dist = fDeikstri(graph, start);

    cout << "Кратчайшие расстояния от вершины " << start << ":" << endl;
    for (int i = 0; i < dist.size(); i++) {
        if (dist[i] == INF)
            cout << "До вершины " << i << ": недостижимо" << endl;
        else
            cout << "До вершины " << i << ": " << dist[i] << endl;
    }



    return 0;
}