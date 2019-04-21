using System;
using System.IO;
using System.Net.Sockets;
using TCPNetwork.Commands;
using TCPNetwork.Network;

namespace TcpServer
{
    class Program
    {
        // todo: сохранять логин/пароль юзеров в файле. Хватит текстового. 
        // todo: хранить непрочитанные сообщения пользователя в файле. Пожалуй, с именем как имя пользователя. username@myServer

        static void Main(string[] args)
        {
            Console.WriteLine("TcpServer Starting...");
            
            //MessageHandler.OnSaveUserCommand += CommandListener_OnSaveUserCommand;
            //
            //




            var commandListener = new CommandListener();

            commandListener.Start();
            Console.WriteLine("TcpServer Started. Press any key to exit.");
            Console.ReadKey();
            commandListener.Stop();
        }


        //private static void CommandListener_OnSaveUserCommand(SaveUserCommand saveUserCommand, TcpClient tcpClient)
        //{
        //    Console.WriteLine("SaveUserCommand accepted, FirstName:{0}, SecondName:{1}", saveUserCommand.FirstName, saveUserCommand.SecondName);
        //    CommandSender.Server.SendResponseToClient(tcpClient);
        //}
    }
}
