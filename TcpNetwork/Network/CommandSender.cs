using System;
using System.Diagnostics;
using System.Net.Sockets;
using TcpNetwork.Commands;
using TcpNetwork.Enums;
using TcpNetwork.Helpers;
using TcpNetwork.Utils;

namespace TcpNetwork.Network
{
    public static class CommandSender
    {
        public static void SendMessageAcceptedToClient(TcpClient tcpClient)
        {
            var commandHeader = new CommandHeader{
                Type = CommandType.MessageAccepted
            };
            SendAnswerToClient(tcpClient, commandHeader.ToBytes());
        }

        public static void SendCommandToServer(string serverIp, BaseCommand command, CommandType typeEnum )
        {
            var commandHeader = new CommandHeader
            {
                Type = typeEnum
            };
            
            byte[] commandBytes = CommandUtils.ConcatByteArrays(commandHeader.ToBytes(), command.ToBytes());
            SendCommandToServer(serverIp, Settings.Port, commandBytes);
        }

        private static void SendCommandToServer(string ipAddress, int port, byte[] messageBytes)
        {
            var client = new TcpClient();
            try
            {
                client.Connect(ipAddress, port);
                byte[] messageBytesWithEof = CommandUtils.AddCommandLength(messageBytes);
                NetworkStream networkStream = client.GetStream();
                networkStream.Write(messageBytesWithEof, 0, messageBytesWithEof.Length);
                MessageHandler.HandleClientMessage(client);
            }
            catch (SocketException exception)
            {
                ConsoleHelpers.error("Cannot sent command to server");
                Trace.WriteLine(exception.Message + " " + exception.InnerException);
            }
        }

        private static void SendAnswerToClient(TcpClient tcpClient, byte[] messageBytes)
        {
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
                ConsoleHelpers.error("Cannot sent answer to client");
                Trace.WriteLine(exception.Message + " " + exception.InnerException);
            }

        }
    }
}
