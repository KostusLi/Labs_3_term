#include <iostream>
#pragma comment(lib, "Ws2_32.lib")
#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS
#include <winsock2.h>
#include <string>
#include <Windows.h>    

using namespace std;

int main() {
    setlocale(LC_ALL, "ru");
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    WSADATA wsaData;
    WSAStartup(MAKEWORD(2, 2), &wsaData);

    while (true) {
        SOCKET s = socket(AF_INET, SOCK_STREAM, 0);
        sockaddr_in dest_addr;
        dest_addr.sin_family = AF_INET;
        dest_addr.sin_port = htons(1280);
        dest_addr.sin_addr.s_addr = inet_addr("127.0.0.1");

        connect(s, (sockaddr*)&dest_addr, sizeof(dest_addr));

        string cmd;
        cout << "Введите команду (VIEW, ADD, EDIT, DELETE, FILTER, EXIT): " << endl;
        getline(cin, cmd);

        if (cmd == "EXIT") break;

        send(s, cmd.c_str(), cmd.size(), 0);

        char buf[2000];
        int bytes = recv(s, buf, sizeof(buf) - 1, 0);
        if (bytes > 0) {
            buf[bytes] = '\0';
            cout << "Ответ сервера:\n" << buf << endl;
        }

        closesocket(s);
    }

    WSACleanup();
    return 0;
}
