using System.IO;
using TcpNetwork.Utils;

namespace TcpNetwork.Commands
{
    public class StringCommand: BaseCommand
    {
        public int StringFieldLength { get; set; }
        public string StringField { get; set; }

        public byte[] ToBytes()
        {
            byte[] stringFieldBytes = CommandUtils.GetBytes(StringField);
            StringFieldLength = stringFieldBytes.Length;
            int messageLength = sizeof(int) + StringFieldLength;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write(StringFieldLength);
                writer.Write(stringFieldBytes);
                return messageData;
            }
        }

        public static StringCommand FromBytes(byte[] bytes)
        {
             using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new StringCommand();

                command.StringFieldLength = br.ReadInt32();
                command.StringField =  CommandUtils.GetString(br.ReadBytes(command.StringFieldLength));

                return command;
            }
        }
    }
}
