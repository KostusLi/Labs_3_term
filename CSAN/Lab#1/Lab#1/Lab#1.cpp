#include <iostream>
#pragma comment (lib,"WSock32.Lib")
#include <WinSock2.h>

using namespace std;

int main()
{
    WORD wVersionRequested;
    WSADATA wsaData;
    wVersionRequested = MAKEWORD(2, 2);
    WSAStartup(wVersionRequested, &wsaData);

    SOCKET s = socket(AF_INET, SOCK_STREAM, 0);

    struct sockaddr_in local;
    local.sin_family = AF_INET;
    local.sin_port = htons(1280);
    local.sin_addr.s_addr = htonl(INADDR_ANY);
    int c = bind(s, (struct sockaddr*)&local, sizeof(local));

    int r = listen(s, 5);

    SOCKET accept (SOCKET s, struct sockaddr FAR * addr, int FAR * addrlen);

    while (true)
    {
        char buf[255], res[100], b[255], * Res;
        sockaddr_in remote_addr;
        int size = sizeof(remote_addr);
        SOCKET s2 = accept(s, (struct sockaddr*)&remote_addr, &size);
    }


}

