using System.IO;
using TCPNetwork.Utils;

namespace TCPNetwork.Commands
{
    public class SendChatMessageCommand : BaseCommand
    {
        public SignInCommand creditials { get; set; } // whoami

        public string Message
        {
            get => Message;
            set => Message = value;
        }

        public int length => Message.Length; 

        public SendChatMessageCommand(string message)
        {
            Message = message;
        }

        public SendChatMessageCommand()
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

        public static SendChatMessageCommand FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new SendChatMessageCommand();

                var creditials = SignInCommand.FromStream(ms);
                command.creditials = creditials;

                var length = br.ReadInt32();

                command.Message = CommandUtils.GetString(br.ReadBytes(length));

                return command;
            }
        }

        public static SendChatMessageCommand FromStream(Stream stream)
        {
            var br = new BinaryReader(stream);
            var command = new SendChatMessageCommand();

            var creditials = SignInCommand.FromStream(stream);
            command.creditials = creditials;

            var length = br.ReadInt32();

            command.Message = CommandUtils.GetString(br.ReadBytes(length));

            return command;
        }
    }
}
