using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using TCPNetwork.Commands;
using TCPNetwork.Enums;
using TCPNetwork.Utils;

namespace TCPNetwork.Network
{
    public static class MessageHandler
    {
        public static Action OnMessageAccepted;

        private delegate BaseCommand CommandFromBytes(byte[] bytes);
        private delegate BaseCommand CommandFromStream(Stream stream);

        private static readonly Dictionary<CommandType, CommandFromBytes> commandsFromBytes = new Dictionary<CommandType, CommandFromBytes>();
        private static readonly Dictionary<CommandType, CommandFromStream> commandsFromStream = new Dictionary<CommandType, CommandFromStream>();

        static MessageHandler()
        {
            FillCommandsDictionaries();
        }

        private static void FillCommandsDictionaries()
        {

            //commandsFromBytes.Add(CommandType.Single, SingleCommand.FromBytes);
            //commandsFromBytes.Add(CommandType.File, FileCommand.FromBytes);

            #region FromBytes
            commandsFromBytes.Add(CommandType.Signup, SignUpCommand.FromBytes);
            commandsFromBytes.Add(CommandType.Signin, SignInCommand.FromBytes);
            commandsFromBytes.Add(CommandType.EnterRoom, EnterRoomCommand.FromBytes);
            commandsFromBytes.Add(CommandType.LeaveRoom, LeaveRoomCommand.FromBytes);
            commandsFromBytes.Add(CommandType.SendChatMessage, SendChatMessageCommand.FromBytes);
            commandsFromBytes.Add(CommandType.ServerResponse, ServerResponseCommand.FromBytes);
            #endregion

            #region FromStream
            commandsFromStream.Add(CommandType.Signup, SignUpCommand.FromStream);
            commandsFromStream.Add(CommandType.Signin, SignInCommand.FromStream);
            commandsFromStream.Add(CommandType.EnterRoom, EnterRoomCommand.FromStream);
            commandsFromStream.Add(CommandType.LeaveRoom, LeaveRoomCommand.FromStream);
            commandsFromStream.Add(CommandType.SendChatMessage, SendChatMessageCommand.FromStream);
            commandsFromStream.Add(CommandType.ServerResponse, ServerResponseCommand.FromStream);
            #endregion
        }

        public static class Server
        {
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


                var tcpClient = (TcpClient)client;
                tcpClient.ReceiveTimeout = 3;
                NetworkStream clientStream = tcpClient.GetStream();

                var ms = new MemoryStream();
                var binaryWriter = new BinaryWriter(ms);

                var message = new byte[tcpClient.ReceiveBufferSize];
                var message2 = new byte[4];
                int readCount;
                int totalReadMessageBytes = 0;

                clientStream.Read(message2, 0, 4);
                int messageLength = CommandUtils.BytesToInt(message2);

                while ((readCount = clientStream.Read(message, 0, tcpClient.ReceiveBufferSize)) != 0)
                {
                    binaryWriter.Write(message, 0, readCount);
                    totalReadMessageBytes += readCount;
                    if (totalReadMessageBytes >= messageLength)
                        break;
                }

                if (ms.Length > 0)
                {
                    Parse(ms.ToArray(), tcpClient);
                }
            }

            private static void Parse(byte[] bytes, TcpClient tcpClient)
            {
                if (bytes.Length >= CommandHeader.GetLength())
                {
                    CommandHeader commandHeader = CommandHeader.FromBytes(bytes);
                    IEnumerable<byte> commandBytes = bytes.Skip(CommandHeader.GetLength());

                    var commandType = commandHeader.Type;
                    
                    // это должно на клиенте быть. На сервере такого быть не должно - это ошибка.
                    if (commandType == CommandType.ServerResponse)
                    {
                        if (OnMessageAccepted != null)
                            OnMessageAccepted();
                    }
                    else
                    {
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
            }
        }

        public static class Client
        {
            public static void HandleServerMessage(object client)
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


                var tcpClient = (TcpClient)client;
                tcpClient.ReceiveTimeout = 3;
                NetworkStream clientStream = tcpClient.GetStream();

                var ms = new MemoryStream();
                var binaryWriter = new BinaryWriter(ms);

                var message = new byte[tcpClient.ReceiveBufferSize];
                var message2 = new byte[4];
                int readCount;
                int totalReadMessageBytes = 0;

                clientStream.Read(message2, 0, 4);
                int messageLength = CommandUtils.BytesToInt(message2);

                while ((readCount = clientStream.Read(message, 0, tcpClient.ReceiveBufferSize)) != 0)
                {
                    binaryWriter.Write(message, 0, readCount);
                    totalReadMessageBytes += readCount;
                    if (totalReadMessageBytes >= messageLength)
                        break;
                }

                if (ms.Length > 0)
                {
                    Parse(ms.ToArray(), tcpClient);
                }
            }

            private static void Parse(byte[] bytes, TcpClient tcpClient)
            {
                if (bytes.Length >= CommandHeader.GetLength())
                {
                    CommandHeader commandHeader = CommandHeader.FromBytes(bytes);
                    IEnumerable<byte> commandBytes = bytes.Skip(CommandHeader.GetLength());

                    var commandType = commandHeader.Type;

                    if (commandType == CommandType.ServerResponse)
                    {
                        if (OnMessageAccepted != null)
                            OnMessageAccepted();
                    }
                    else
                    {
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
            }


        }
    }


}
