#include <iostream>
#include <vector>
#include <queue>
using namespace std;

const int INF = 1e9;


void dfsList(const vector<vector<int>>& graph, int v, vector<int>& visited) {
    visited[v] = 1;
    cout << v + 1 << " ";
    for (int to : graph[v])
        if (!visited[to])
            dfsList(graph, to, visited);
}


void dfsMatrix(const vector<vector<int>>& graph, int v, vector<int>& visited) {
    visited[v] = 1;
    cout << v + 1 << " ";
    for (int to = 0; to < graph.size(); to++)
        if (graph[v][to] && !visited[to])
            dfsMatrix(graph, to, visited);
}


vector<int> bfsList(const vector<vector<int>>& graph, int start) {
    vector<int> dist(graph.size(), INF);
    queue<int> q;

    dist[start] = 0;
    q.push(start);

    while (!q.empty()) {
        int v = q.front();
        q.pop();

        for (int to : graph[v]) {
            if (dist[to] > dist[v] + 1) {
                dist[to] = dist[v] + 1;
                q.push(to);
            }
        }
    }
    return dist;
}


vector<int> bfsMatrix(const vector<vector<int>>& graph, int start) {
    vector<int> dist(graph.size(), INF);
    queue<int> q;

    dist[start] = 0;
    q.push(start);

    while (!q.empty()) {
        int v = q.front();
        q.pop();

        for (int to = 0; to < graph.size(); to++) {
            if (graph[v][to] && dist[to] > dist[v] + 1) {
                dist[to] = dist[v] + 1;
                q.push(to);
            }
        }
    }
    return dist;
}


void printGr(vector<int> dist, int vertexCount)
{
    for (int i = 0; i < vertexCount; i++) {
        if (dist[i] != INF) cout << dist[i] << " ";
        else cout << "INF ";
    }
    cout << endl;
}

int main() {
    setlocale(LC_ALL, "ru");

    int vertexCount = 10;

    vector<vector<int>> adjList = {
        {1, 4},      
        {0, 6, 7},    
        {7},         
        {5, 8},      
        {0, 5},       
        {3, 4, 8},   
        {1},          
        {1, 2},      
        {3, 5, 9},    
        {8}           
    };


    vector<vector<int>> adjMatrix = {
        {0,1,0,0,1,0,0,0,0,0},
        {1,0,0,0,0,0,1,1,0,0}, 
        {0,0,0,0,0,0,0,1,0,0}, 
        {0,0,0,0,0,1,0,0,1,0}, 
        {1,0,0,0,0,1,0,0,0,0}, 
        {0,0,0,1,1,0,0,0,1,0}, 
        {0,1,0,0,0,0,0,0,0,0}, 
        {0,1,1,0,0,0,0,0,0,0}, 
        {0,0,0,1,0,1,0,0,0,1}, 
        {0,0,0,0,0,0,0,0,1,0}  
    };


    vector<pair<int, int>> edgeList = {
       {0, 1}, 
       {0, 4}, 
       {1, 6}, 
       {1, 7}, 
       {2, 7}, 
       {3, 5}, 
       {3, 8}, 
       {4, 5}, 
       {5, 8}, 
       {8, 9}  
    };


    int startVertex = 0; 

    cout << "=== Обход в глубину (DFS) ===" << endl;

    cout << "Список смежности: ";
    vector<int> visited(vertexCount, 0);
    dfsList(adjList, startVertex, visited);
    cout << endl;

    cout << "Матрица смежности: ";
    fill(visited.begin(), visited.end(), 0);
    dfsMatrix(adjMatrix, startVertex, visited);
    cout << endl;

    cout << "\n=== Обход в ширину (BFS) ===" << endl;

    cout << "Список смежности: ";
    vector<int> dist = bfsList(adjList, startVertex);
    printGr(dist, vertexCount);

    cout << "Матрица смежности: ";
    dist = bfsMatrix(adjMatrix, startVertex);
    printGr(dist, vertexCount);

    return 0;
}