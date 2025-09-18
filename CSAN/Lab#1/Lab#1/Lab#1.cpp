#include <iostream>
#pragma comment (lib,"WSock32.Lib")
#include <winsock2.h>
#include <ws2tcpip.h>


using namespace std;

int main() {
	WORD wVersionRequested;
    WSADATA wsaData;
	wVersionRequested = MAKEWORD(2, 2); 
	WSAStartup(wVersionRequested, &wsaData);

    SOCKET s = socket(AF_INET, SOCK_STREAM, 0);

    sockaddr_in local;
    local.sin_family = AF_INET;
    local.sin_port = htons(1280);
    local.sin_addr.s_addr = htonl(INADDR_ANY);

    if (bind(s, (struct sockaddr*)&local, sizeof(local)) == SOCKET_ERROR) {
        cout << "Bind failed: " << WSAGetLastError() << endl;
        return 1;
    }

    if (listen(s, 5) == SOCKET_ERROR) {
        cout << "Listen failed: " << WSAGetLastError() << endl;
        return 1;
    }

    while (true) {
        sockaddr_in remote_addr;
        int size = sizeof(remote_addr);
        SOCKET s2 = accept(s, (struct sockaddr*)&remote_addr, &size);
        if (s2 == INVALID_SOCKET) continue;

        char b[255], word1[100], word2[100];
        bool check = false;

        while (true) {
            int bytes = recv(s2, b, sizeof(b) - 1, 0);
            if (bytes <= 0) break;
            b[bytes] = '\0';

            int i = 0;
            int k = 0;
            bool check = false;

            for (int j = 0; j < bytes; j++) {
                if (b[j] == '|') {
                    word1[i] = '\0';
                    check = true;
                    continue;
                }

                if (!check) {
                    word1[i++] = b[j];
                }
                else {
                    word2[k++] = b[j];
                }
            }
            word2[k] = '\0';

            string result = "True";

            if (strlen(word1) != strlen(word2)) {
                result = "False";
            }

            for (int j = 0; word1[j] != '\0' &&  word2[j] != '\0'; j++) {
                if (word1[j] != word2[j]){
                    result = "False";
                    break;
                }
            }

            

            send(s2, result.c_str(), (int)result.size(), 0);
        }

        closesocket(s2);
    }


}

