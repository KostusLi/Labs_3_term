#include <iostream>
#include <string>
#include <queue>
#include <unordered_map>
#include <Windows.h>
using namespace std;

struct Node
{
    char ch;
    int freq;
    Node* left, * right;
};

Node* getNode(char ch, int freq, Node* left, Node* right)
{
    Node* node = new Node();

    node->ch = ch;
    node->freq = freq;
    node->left = left;
    node->right = right;

    return node;
}

struct comp
{
    bool operator()(Node* l, Node* r)
    {
        return l->freq > r->freq;
    }
};

void encode(Node* root, string str, unordered_map<char, string>& huffmanCode)
{
    if (root == nullptr)
        return;

    if (!root->left && !root->right) {
        huffmanCode[root->ch] = str;
    }

    encode(root->left, str + "0", huffmanCode);
    encode(root->right, str + "1", huffmanCode);
}

void decode(Node* root, int& index, string str)
{
    if (root == nullptr) {
        return;
    }

    if (!root->left && !root->right)
    {
        cout << root->ch;
        return;
    }

    index++;

    if (str[index] == '0')
        decode(root->left, index, str);
    else
        decode(root->right, index, str);
}

void buildHuffmanTree(string text)
{
    unordered_map<char, int> freq;
    for (char ch : text) {
        freq[ch]++;
    }

    cout << "\nТаблица частот символов:\n";
    for (auto it : freq)
    {
        cout << it.first << " - " << it.second << endl;
    }

    priority_queue<Node*, vector<Node*>, comp> pq;

    for (auto pair : freq) {
        pq.push(getNode(pair.first, pair.second, nullptr, nullptr));
    }

    while (pq.size() != 1)
    {
        Node* left = pq.top(); pq.pop();
        Node* right = pq.top(); pq.pop();

        int sum = left->freq + right->freq;
        pq.push(getNode('\0', sum, left, right));
    }

    Node* root = pq.top();

    unordered_map<char, string> huffmanCode;
    encode(root, "", huffmanCode);

    cout << "\nКоды Хаффмана:\n\n";
    for (auto pair : huffmanCode) {
        cout << pair.first << " " << pair.second << '\n';
    }

    cout << "\nИсходная строка:\n" << text << '\n';

    string str = "";
    for (char ch : text) {
        str += huffmanCode[ch];
    }

    cout << "\nЗакодированная строка:\n" << str << '\n';

    int index = -1;
    cout << "\nДекодированная строка:\n";
    while (index < (int)str.size() - 2) {
        decode(root, index, str);
    }
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "ru");
    string text;

    cout << "Введите строку: ";
    cin.clear();
    getline(cin, text);

    buildHuffmanTree(text);

    return 0;
}
