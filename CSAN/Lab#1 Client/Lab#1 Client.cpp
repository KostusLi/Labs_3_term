#include <winsock2.h>
#include <ws2tcpip.h>
#pragma comment(lib, "Ws2_32.lib")
#include <iostream>
#include <string>

using namespace std;

int main() {
    WORD wVersionRequested = MAKEWORD(2, 2);
    WSADATA wsaData;
    if (WSAStartup(wVersionRequested, &wsaData) != 0) {
        cout << "WSAStartup failed" << endl;
        return 1;
    }

    SOCKET s = socket(AF_INET, SOCK_STREAM, 0);
    if (s == INVALID_SOCKET) {
        cout << "Socket creation failed: " << WSAGetLastError() << endl;
        WSACleanup();
        return 1;
    }

    sockaddr_in peer{};
    peer.sin_family = AF_INET;
    peer.sin_port = htons(1280);

    if (InetPtonA(AF_INET, "127.0.0.1", &peer.sin_addr) <= 0) {
        cout << "Invalid address" << endl;
        closesocket(s);
        WSACleanup();
        return 1;
    }

    if (connect(s, (struct sockaddr*)&peer, sizeof(peer)) == SOCKET_ERROR) {
        cout << "Connect failed: " << WSAGetLastError() << endl;
        closesocket(s);
        WSACleanup();
        return 1;
    }

    string word1, word2;
    cout << "Enter first word: ";
    getline(cin, word1);
    cout << "Enter second word: ";
    getline(cin, word2);

    
    string message = word1 + "|" + word2;

    send(s, message.c_str(), (int)message.size(), 0);

    char b[255];
    int bytes = recv(s, b, sizeof(b) - 1, 0);
    if (bytes > 0) {
        b[bytes] = '\0';
        cout << "Server response: " << b << endl;
    }

    closesocket(s);
    WSACleanup();
    return 0;
}
