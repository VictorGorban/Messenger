
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPNetwork.Network
{
    public class CommandListener
    {
        private readonly TcpListener _tcpListener;
        private Thread _listenThread;
        private bool _continueListen = true;
        private ParameterizedThreadStart _WhatToDo = null;

        public CommandListener(ParameterizedThreadStart whatToDo)
        {
            _tcpListener = new TcpListener(IPAddress.Any, Settings.Port);
            _WhatToDo = whatToDo;
        }

        public void Start()
        {
            _listenThread = new Thread(ListenForClients);
            _listenThread.Start();
        }

        private void ListenForClients()
        {
            _tcpListener.Start();

            while (_continueListen)
            {
                TcpClient client = _tcpListener.AcceptTcpClient();

                var clientThread = new Thread(_WhatToDo);
                clientThread.Start(client);
            }
            _tcpListener.Stop();
        }

        public void Stop()
        {
            _continueListen = false;
            _tcpListener.Stop();
            _listenThread.Abort();
        }

    }
}

