#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS
#pragma comment(lib, "Ws2_32.lib")
#include <iostream>
#include <winsock2.h>
#include <string>
#include <vector>
#include <sstream>
#include <Windows.h>

using namespace std;

struct Employee {
    string fio;
    string number;
    int workHours;
    int costHours;
};

vector<Employee> info = {
    {"Джеймс Тиберий Кирк", "0001", 50, 50},
    {"Сэм Питер Паркер", "0002", 40, 54},
    {"Гай Юлий Цезарь", "0003", 12, 78},
    {"Отто фон Бисмарк", "0004", 67, 23},
    {"Элвин Каллам Йорк", "0005", 34, 89}
};

string command(const string& cmdLine) {
    stringstream ss(cmdLine);
    string cmd;
    ss >> cmd;

    if (cmd == "VIEW") {
        string result;
        for (auto& e : info) {
            int salary = e.workHours * e.costHours;
            result += e.fio + " | " + e.number + " | " +
                to_string(e.workHours) + " ч | " +
                to_string(e.costHours) + " $/ч | ЗП=" +
                to_string(salary) + "\n";
        }
        return result.empty() ? "Нет сотрудников\n" : result;
    }
    else if (cmd == "ADD") {
        Employee e;
        ss >> ws;
        getline(ss, e.fio, '|');
        ss >> e.number >> e.workHours >> e.costHours;
        for (auto i = info.begin(); i < info.end(); i++)
        {
            if (i->number == e.number) return "Не может быть сотрудников с одинаковыми номерами!\n";
        }
        info.push_back(e);
        return "Сотрудник добавлен\n";
    }
    else if (cmd == "EDIT") {
        string number;
        int sal, ch;
        ss >> number >> sal >> ch;
        for (auto& e : info) {
            if (e.number == number) {
                e.workHours = sal;
                e.costHours = ch;
                return "Сотрудник обновлён\n";
            }
        }
        return "Сотрудник не найден\n";
    }
    else if (cmd == "DELETE") {
        string number;
        ss >> number;
        for (auto it = info.begin(); it != info.end(); ++it) {
            if (it->number == number) {
                info.erase(it);
                return "Сотрудник удалён\n";
            }
        }
        return "Сотрудник не найден\n";
    }
    else if (cmd == "FILTER") {
        int salary;
        ss >> salary;
        string result;
        for (auto& e : info) {
            int temp = e.workHours * e.costHours;
            if (temp < salary) {
                result += e.fio + " | " + e.number + " | " +
                    to_string(e.workHours) + " ч | " +
                    to_string(e.costHours) + " $/ч | ЗП=" +
                    to_string(temp) + "\n";
            }
        }
        return result.empty() ? "Нет сотрудников с меньшей зарплатой\n" : result;
    }

    return "Неизвестная команда\n";
}

DWORD WINAPI ThreadFunc(LPVOID client_socket) {
    SOCKET s2 = *((SOCKET*)client_socket);
    char buf[1024];

    while (true) {
        int bytes = recv(s2, buf, sizeof(buf) - 1, 0);
        if (bytes <= 0) break;
        buf[bytes] = '\0';

        string response = command(buf);
        send(s2, response.c_str(), response.size(), 0);
    }

    delete (SOCKET*)client_socket;
    closesocket(s2);
    return 0;
}

int numcl = 0;

void print() {
    if (numcl) printf("%d client connected\n", numcl);
    else printf("No clients connected\n");
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    WSADATA wsaData;
    WSAStartup(MAKEWORD(2, 2), &wsaData);

    SOCKET s = socket(AF_INET, SOCK_STREAM, 0);
    sockaddr_in local_addr;
    local_addr.sin_family = AF_INET;
    local_addr.sin_port = htons(1280);
    local_addr.sin_addr.s_addr = 0;
    bind(s, (sockaddr*)&local_addr, sizeof(local_addr));

    listen(s, 5);
    cout << "Server ready" << endl;

    SOCKET client_socket;
    sockaddr_in client_addr;
    int client_addr_size = sizeof(client_addr);

    while ((client_socket = accept(s, (sockaddr*)&client_addr, &client_addr_size))) {
        numcl++;
        print();
        DWORD thID;
        SOCKET* snew = new SOCKET(client_socket);
        CreateThread(NULL, 0, ThreadFunc, snew, 0, &thID);
    }
    WSACleanup();
    return 0;
}
