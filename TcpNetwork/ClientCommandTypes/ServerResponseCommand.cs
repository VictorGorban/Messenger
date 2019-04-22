using System.IO;
using TCPNetwork.Enums;
using TCPNetwork.Utils;

namespace TCPNetwork.ClientCommandTypes
{
    public class ServerResponseCommand : BaseCommand
    {
        public StatusCode statusCode;
        public ServerResponseType responseType;

        /// <summary>
        /// Обычная строка или массив строк
        /// </summary>
        public string Message { get; set; } // обычная строка или массив строк в base64(сериализация, короче)
        public int MessageLength => Message!=null ? Message.Length : 0;
    
        public byte[] ToBytes()
        {
            int messageLength = sizeof(StatusCode)+ sizeof(ServerResponseType) + sizeof(int) + MessageLength;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write((int)statusCode);
                writer.Write((int)responseType);

                writer.Write(MessageLength);
                writer.Write(CommandUtils.GetBytes(Message));

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
                command.responseType = (ServerResponseType)br.ReadInt32();

                var messageLength = br.ReadInt32();
                command.Message = CommandUtils.GetString(br.ReadBytes(messageLength));

                return command;
            }
        }

        public static ServerResponseCommand FromStream(Stream stream)
        {
                var br = new BinaryReader(stream);
                var command = new ServerResponseCommand();

                command.statusCode = (StatusCode)br.ReadInt32();
                command.responseType = (ServerResponseType)br.ReadInt32();

                var messageLength = br.ReadInt32();
                command.Message = CommandUtils.GetString(br.ReadBytes(messageLength));

                return command;
        }

        public static ServerResponseCommand Error(ServerResponseType responseType, string message = "An error occured")
        {
            return new ServerResponseCommand
            {
                statusCode = StatusCode.Error,
                responseType = responseType,
                Message = message
            };
        }

        public static ServerResponseCommand OK(ServerResponseType responseType, string message = "It's all OK!")
        {
            return new ServerResponseCommand
            {
                statusCode = StatusCode.OK,
                responseType = responseType,
                Message = message
            };
        }
    }
}
