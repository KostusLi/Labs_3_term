#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <winsock2.h>
#pragma comment(lib, "WSock32.Lib")
#include <iostream>
#include <cstring>

using namespace std;

int main() { 
    WORD wVersionRequested;
    WSADATA wsaData;
    int err;
    wVersionRequested = MAKEWORD(2, 2);
    err = WSAStartup(wVersionRequested, &wsaData);

    if (err != 0) {
        cout << "WSAStartup failed: " << err << endl;
        return 1;
    }

    SOCKET s = socket(AF_INET, SOCK_DGRAM, 0);
    if (s == INVALID_SOCKET) {
        cout << "Socket creation failed: " << WSAGetLastError() << endl;
        WSACleanup();
        return 1;
    }

    struct sockaddr_in ad;
    ad.sin_family = AF_INET;
    ad.sin_port = htons(1024);
    ad.sin_addr.s_addr = INADDR_ANY;

    if (bind(s, (struct sockaddr*)&ad, sizeof(ad)) == SOCKET_ERROR) {
        cout << "Bind failed: " << WSAGetLastError() << endl;
        closesocket(s);
        WSACleanup();
        return 1;
    }


    while (true) {
        char b[200] = { 0 }; 
        char res[200] = { 0 };

        int l = sizeof(ad);

        int rv = recvfrom(s, b, sizeof(b) - 1, 0, (struct sockaddr*)&ad, &l);

        if (rv == SOCKET_ERROR) {
            cout << "Receive failed: " << WSAGetLastError() << endl;
            continue;
        }

        b[rv] = '\0';

        if (strlen(b) % 2 != 0) {
            int k = strlen(b) / 2;
            int n = 0;

            for (int i = 0; i < strlen(b); i++) {
                if (i == k) {
                    continue;
                }
                res[n++] = b[i];
            }
            res[n] = '\0';
        }
        else {
            strcpy_s(res, b);
        }

        cout << "Sending response: " << res << endl;

        int sent = sendto(s, res, strlen(res), 0, (struct sockaddr*)&ad, l);
        if (sent == SOCKET_ERROR) {
            cout << "Send failed: " << WSAGetLastError() << endl;
        }
    }

    closesocket(s);
    WSACleanup();
    return 0;
}