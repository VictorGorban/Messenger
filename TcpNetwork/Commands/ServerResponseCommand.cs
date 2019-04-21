using System.IO;
using TcpNetwork.Enums;
using TcpNetwork.Utils;

namespace TcpNetwork.Commands
{
    public class ServerResponseCommand : BaseCommand
    {
        public StatusCode statusCode;
        public CommandType commandType;

        public string Message { get; set; }
        public int MessageLength => Message.Length;

        public byte[] ToBytes()
        {
            byte[] messageBytes = CommandUtils.GetBytes(Message);

            int messageLength = sizeof(StatusCode)+ sizeof(CommandType) + sizeof(int) + MessageLength;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write((int)statusCode);
                writer.Write((int)commandType);

                writer.Write(MessageLength);
                writer.Write(messageBytes);

                return messageData;
            }
        }

        public static ServerResponseCommand FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new ServerResponseCommand();

                command.statusCode = (StatusCode)br.ReadInt32();
                command.commandType = (CommandType)br.ReadInt32();

                var messageLength = br.ReadInt32();
                command.Message = CommandUtils.GetString(br.ReadBytes(messageLength));

                return command;
            }
        }

        public static ServerResponseCommand Error(CommandType commandType, string message = "An error occured")
        {
            return new ServerResponseCommand
            {
                statusCode = StatusCode.Error,
                commandType = commandType,
                Message = message
            };
        }

        public static ServerResponseCommand OK(CommandType commandType, string message = "It's all OK!")
        {
            return new ServerResponseCommand
            {
                statusCode = StatusCode.OK,
                commandType = commandType,
                Message = message
            };
        }
    }
}
