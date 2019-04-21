using System;
using System.Diagnostics;
using System.Net.Sockets;
using TCPNetwork.Commands;
using TCPNetwork.Enums;
using TCPNetwork.Helpers;
using TCPNetwork.Utils;

namespace TCPNetwork.Network
{
    public static class CommandSender
    {
        public static class Client
        {
            public static bool SendCommandToServer(string serverIp, BaseCommand command, CommandType typeEnum)
            {
                var commandHeader = new CommandHeader
                {
                    Type = typeEnum
                };

                byte[] messageBytes = CommandUtils.ConcatByteArrays(commandHeader.ToBytes(), command.ToBytes());

                var client = new TcpClient();
                try
                {
                    client.Connect(serverIp, Settings.Port);
                    byte[] messageBytesWithEof = CommandUtils.AddCommandLength(messageBytes);
                    NetworkStream networkStream = client.GetStream();
                    networkStream.Write(messageBytesWithEof, 0, messageBytesWithEof.Length);
                    MessageHandler.Server.HandleClientMessage(client);
                }
                catch (SocketException exception)
                {
                    //ConsoleHelpers.error("Cannot sent command to server");
                    Trace.WriteLine(exception.Message + " " + exception.InnerException);
                    return false;
                }

                return true;
            }

            private static void SendCommandToServer(string ipAddress, int port, byte[] messageBytes)
            {
                
            }
        }

        public static class Server
        {
            public static bool SendResponseToClient(TcpClient tcpClient, ServerResponseCommand responseCommand)
            {
                if (tcpClient is null || responseCommand is null)
                    throw new ArgumentNullException();

                var messageBytes = responseCommand.ToBytes();

                try
                {
                    byte[] messageBytesWithEof = CommandUtils.AddCommandLength(messageBytes);
                    NetworkStream networkStream = tcpClient.GetStream();
                    networkStream.Write(messageBytesWithEof, 0, messageBytesWithEof.Length);
                    networkStream.Close();
                    tcpClient.Close();
                }
                catch (SocketException exception)
                {
                    //ConsoleHelpers.error("Cannot sent answer to client");
                    Trace.WriteLine(exception.Message + " " + exception.InnerException);
                    return false;
                }

                return true;

            }
        }
        
    }
}
