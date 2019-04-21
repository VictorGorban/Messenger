using System.IO;
using TcpNetwork.Utils;

namespace TcpNetwork.Commands
{
    public class SendMessageCommand : BaseCommand
    {
        public SignInCommand signin { get; set; } // whoami

        public string Message
        {
            get => Message;
            set => Message = value;
        }

        public int length => Message.Length; 

        public SendMessageCommand(string message)
        {
            Message = message;
        }

        public SendMessageCommand()
        {
        }

        public byte[] ToBytes()
        {
            byte[] stringFieldBytes = CommandUtils.GetBytes(Message);
            var length = stringFieldBytes.Length;
            // int + string
            int messageLength = sizeof(int) + length;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write(length);
                writer.Write(stringFieldBytes);
                return messageData;
            }
        }

        public static SendMessageCommand FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new SendMessageCommand();

                var signin = SignInCommand.FromStream(ms);
                command.signin = signin;

                var length = br.ReadInt32();

                command.Message = CommandUtils.GetString(br.ReadBytes(length));

                return command;
            }
        }
    }
}
