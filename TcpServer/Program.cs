using System;
using System.IO;
using System.Net.Sockets;
using TcpNetwork.Commands;
using TcpNetwork.Network;

namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TcpServer Starting...");
            MessageHandler.OnSingleCommand += CommandListener_OnSingleCommand;
            MessageHandler.OnStringCommand += CommandListener_OnStringCommand;
            MessageHandler.OnFileCommand += CommandListener_OnFileCommand;
            MessageHandler.OnSaveUserCommand += CommandListener_OnSaveUserCommand;
            var commandListener = new CommandListener();

            commandListener.Start();
            Console.WriteLine("TcpServer Started. Press any key to exit.");
            Console.ReadKey();
            commandListener.Stop();
        }

        private static void CommandListener_OnSingleCommand(SingleCommand singleCommand, TcpClient tcpClient)
        {
            Console.WriteLine("SingleCommand accepted, IntField:{0}, DecimalField:{1}", singleCommand.IntField, singleCommand.DecimalField);
            CommandSender.SendMessageAcceptedToClient(tcpClient);
        }

        private static void CommandListener_OnStringCommand(StringCommand stringCommand, TcpClient tcpClient)
        {
            Console.WriteLine("StringCommand accepted, StringField:{0}", stringCommand.StringField);
            CommandSender.SendMessageAcceptedToClient(tcpClient);
        }

        private static void CommandListener_OnFileCommand(FileCommand fileCommand, TcpClient tcpClient)
        {
            File.WriteAllBytes(fileCommand.FileName, fileCommand.FileBytes);
            Console.WriteLine("StringCommand accepted, FileName:{0}", fileCommand.FileName);
            CommandSender.SendMessageAcceptedToClient(tcpClient);
        }

        private static void CommandListener_OnSaveUserCommand(SaveUserCommand saveUserCommand, TcpClient tcpClient)
        {
            Console.WriteLine("SaveUserCommand accepted, FirstName:{0}, SecondName:{1}", saveUserCommand.FirstName, saveUserCommand.SecondName);
            CommandSender.SendMessageAcceptedToClient(tcpClient);
        }
    }
}
