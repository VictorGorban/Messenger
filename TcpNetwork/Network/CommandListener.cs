using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TcpNetwork.Network
{
    public class CommandListener
    {
        private readonly TcpListener _tcpListener;
        private Thread _listenThread;
        private bool _continueListen = true;

        public CommandListener()
        {
            _tcpListener = new TcpListener(IPAddress.Any, Settings.Port);
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

                var clientThread = new Thread(HandleClientComm);
                clientThread.Start(client);
            }
            _tcpListener.Stop();
        }

        private void HandleClientComm(object client)
        {
            MessageHandler.HandleClientMessage(client);
        }

        public void Stop()
        {
            _continueListen = false;
            _tcpListener.Stop();
            _listenThread.Abort();
        }

    }
}
