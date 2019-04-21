using System.IO;
using TcpNetwork.Utils;

namespace TcpNetwork.Commands
{
    public class SaveUserCommand : BaseCommand
    {
        private int FirstNameLength { get; set; }
        public string FirstName { get; set; }

        private int SecondNameLength { get; set; }
        public string SecondName { get; set; }

        public byte[] ToBytes()
        {
            byte[] firstNamebytes = CommandUtils.GetBytes(FirstName);
            FirstNameLength = firstNamebytes.Length;

            byte[] secondNamebytes = CommandUtils.GetBytes(SecondName);
            SecondNameLength = secondNamebytes.Length;

            int messageLength = sizeof(int) * 2 + FirstNameLength + SecondNameLength;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write(FirstNameLength);
                writer.Write(firstNamebytes);

                writer.Write(SecondNameLength);
                writer.Write(secondNamebytes);

                return messageData;
            }
        }

        public static SaveUserCommand FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new SaveUserCommand();

                command.FirstNameLength = br.ReadInt32();
                command.FirstName = CommandUtils.GetString(br.ReadBytes(command.FirstNameLength));

                command.SecondNameLength = br.ReadInt32();
                command.SecondName = CommandUtils.GetString(br.ReadBytes(command.SecondNameLength));

                return command;
            }
        }
    }
}
