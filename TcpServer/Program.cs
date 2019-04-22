using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using TCPNetwork.ClientCommandTypes;
using TCPNetwork.Enums;
using TCPNetwork.Network;
using TCPNetwork.Utils;

namespace TcpServer
{
    internal class Program
    {
        // todo: сохранять логин/пароль юзеров в файле. Хватит текстового. 
        // todo: хранить непрочитанные сообщения пользователя в файле. Пожалуй, с именем как имя пользователя. username@myServer

        private static void Main(string[] args)
        {
            Console.WriteLine("TcpServer Starting...");

            //MessageHandler.OnSaveUserCommand += CommandListener_OnSaveUserCommand;
            //
            //




            var commandListener = new CommandListener(HandleClientMessage);

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

        #region CommandSender
        private delegate BaseCommand CommandFromBytes(byte[] bytes);
        private delegate BaseCommand CommandFromStream(Stream stream);

        private static readonly Dictionary<ClientCommandType, CommandFromBytes> commandsFromBytes = new Dictionary<ClientCommandType, CommandFromBytes>();
        private static readonly Dictionary<ClientCommandType, CommandFromStream> commandsFromStream = new Dictionary<ClientCommandType, CommandFromStream>();



        // parse нужно объединить с этим. Автор поста решил разбить на два метода, этим разбил логику. Мою.
        // Это должно быть на сервере. Подобное - на клиенте.
        public static void HandleClientMessage(object client)
        {
            /** Алгоритм:
             *  Определить тип сообщения
             *  в зависимости от этого, 
             *      распарсить байты сообщения (подойдет Dictionary с методами FromStream.)
             *      предпринять действия
             *      отправить ответ.
             *      
             *  
             *  
             *  
             */


            var tcpClient = (System.Net.Sockets.TcpClient)client;
            tcpClient.ReceiveTimeout = 3;
            NetworkStream clientStream = tcpClient.GetStream();

            var ms = new MemoryStream();
            var binaryWriter = new BinaryWriter(ms);

            var messageLengthBytes = new byte[4];
            var messageBytes = new byte[tcpClient.ReceiveBufferSize];
            int readCount;
            int totalReadMessageBytes = 0;

            clientStream.Read(messageLengthBytes, 0, sizeof(int));
            int messageLength = CommandUtils.BytesToInt(messageLengthBytes);

            while ((readCount = clientStream.Read(messageBytes, 0, tcpClient.ReceiveBufferSize)) != 0)
            {
                binaryWriter.Write(messageBytes, 0, readCount);
                totalReadMessageBytes += readCount;
                if (totalReadMessageBytes >= messageLength)
                    break;
            }

            if (ms.Length > 0)
            {
                ParseMessageBytesAndRespondToClient(ms.ToArray(), tcpClient);
            }
        }

        private static void ParseMessageBytesAndRespondToClient(byte[] bytes, System.Net.Sockets.TcpClient tcpClient)
        {
            if (bytes.Length >= ClientCommandHeader.GetLength())
            {
                ClientCommandHeader commandHeader = ClientCommandHeader.FromBytes(bytes);
                IEnumerable<byte> commandBytes = bytes.Skip(ClientCommandHeader.GetLength());

                var commandType = commandHeader.Type;

                BaseCommand baseCommand = commandsFromBytes[commandType].Invoke(commandBytes.ToArray());

                switch (commandType)
                {
                    //case CommandType.SendChatMessage:
                    //    if (OnStringCommand != null)
                    //        OnStringCommand((StringCommand)baseCommand, tcpClient);
                    //    break;
                    //case CommandType.Single:
                    //    if (OnSingleCommand != null)
                    //        OnSingleCommand((SingleCommand)baseCommand, tcpClient);
                    //    break;
                    //case CommandType.File:
                    //    if (OnSingleCommand != null)
                    //        OnFileCommand((FileCommand)baseCommand, tcpClient);
                    //    break;
                    //case CommandType.SaveUser:
                    //    if (OnSingleCommand != null)
                    //        OnSaveUserCommand((SaveUserCommand)baseCommand, tcpClient);
                    //    break;
                }
            }
        }
        #endregion



        public static bool SendResponseToClient(TcpClient tcpClient, ServerResponseCommand responseCommand)
        {
            if (tcpClient is null || responseCommand is null)
                throw new ArgumentNullException();

            var messageBytes = responseCommand.ToBytes();

            try
            {
                byte[] messageBytesWithEof = CommandUtils.PrependLengthBytes(messageBytes);
                NetworkStream networkStream = tcpClient.GetStream();
                networkStream.Write(messageBytesWithEof, 0, messageBytesWithEof.Length);
                networkStream.Close();
                tcpClient.Close();
            }
            catch (SocketException exception)
            {
                //ConsoleHelpers.error("Cannot sent answer to client");
                return false;
            }

            return true;

        }
    }
}
