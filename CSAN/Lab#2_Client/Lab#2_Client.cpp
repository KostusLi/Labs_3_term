#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <string>
#pragma comment(lib,"WSock32.Lib")
#include <winsock2.h>
#include <windows.h>
#include <iostream>

using namespace std;

int main(void) {
    char buf[100], b[100];
    WORD wVersionRequested;
    WSADATA wsaData;
    int err;
    wVersionRequested = MAKEWORD(2, 2);
    err = WSAStartup(wVersionRequested, &wsaData);
    if (err != 0) { return 0; }

    SOCKET s;
    s = socket(AF_INET, SOCK_DGRAM, 0);

    sockaddr_in add;
    add.sin_family = AF_INET;
    add.sin_port = htons(1024);

    add.sin_addr.s_addr = inet_addr("127.0.0.1");
    if (add.sin_addr.s_addr == INADDR_NONE) {
        cout << "Invalid address" << endl;
        closesocket(s);
        WSACleanup();
        return 1;
    } 

    int t = sizeof(add);
    cout << "Enter string, please: ";
    cin >> buf;

    int sent = sendto(s, buf, sizeof(buf), 0, (struct sockaddr*)&add, t);
    if (sent == SOCKET_ERROR) {
        cout << "Send failed: " << WSAGetLastError() << endl;
    }

    int rv = recvfrom(s, b, sizeof(b) - 1, 0, (struct sockaddr*)&add, &t);
    if (rv == SOCKET_ERROR) {
        cout << "Receive failed: " << WSAGetLastError() << endl;
    }
    else {
        b[rv] = '\0';
        cout << b << endl;
    }

    closesocket(s);
    WSACleanup();
    return 0;
}