using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using TcpNetwork.Commands;
using TcpNetwork.Enums;
using TcpNetwork.Utils;

namespace TcpNetwork.Network
{
    public static class MessageHandler
    {
        public static Action<StringCommand, TcpClient> OnStringCommand;
        public static Action<SingleCommand, TcpClient> OnSingleCommand;
        public static Action<FileCommand, TcpClient> OnFileCommand;
        public static Action<SaveUserCommand, TcpClient> OnSaveUserCommand;
        public static Action OnMessageAccepted;

        private delegate BaseCommand DeselialiseBytesToCommand(byte[] bytes);

        private static readonly Dictionary<CommandType, DeselialiseBytesToCommand> BytesToCommands = new Dictionary<CommandType, DeselialiseBytesToCommand>();

        static MessageHandler()
        {
            FillBytesToCommandsDictionary();
        }

        private static void FillBytesToCommandsDictionary()
        {
            BytesToCommands.Add(CommandType.SendMessage, StringCommand.FromBytes);
            BytesToCommands.Add(CommandType.Single, SingleCommand.FromBytes);
            BytesToCommands.Add(CommandType.File, FileCommand.FromBytes);
            BytesToCommands.Add(CommandType.SaveUser, SaveUserCommand.FromBytes);
        }

        public static void HandleClientMessage(object client)
        {
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
        IEnumerable<byte> nextCommandBytes = bytes.Skip(CommandHeader.GetLength());

        var commandTypeEnum = (CommandType)commandHeader.Type;

        if (commandTypeEnum == CommandType.MessageAccepted)
        {
            if (OnMessageAccepted != null)
                OnMessageAccepted();
        }
        else
        {
            BaseCommand baseCommand = BytesToCommands[commandTypeEnum].Invoke(nextCommandBytes.ToArray());

            switch (commandTypeEnum)
            {
                case CommandType.SendMessage:
                    if (OnStringCommand != null)
                        OnStringCommand((StringCommand)baseCommand, tcpClient);
                    break;
                case CommandType.Single:
                    if (OnSingleCommand != null)
                        OnSingleCommand((SingleCommand)baseCommand, tcpClient);
                    break;
                case CommandType.File:
                    if (OnSingleCommand != null)
                        OnFileCommand((FileCommand)baseCommand, tcpClient);
                    break;
                case CommandType.SaveUser:
                    if (OnSingleCommand != null)
                        OnSaveUserCommand((SaveUserCommand)baseCommand, tcpClient);
                    break;
            }
        }
    }
}
    }
}
