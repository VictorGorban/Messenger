using System.IO;

namespace TcpNetwork.Commands
{
    public class SingleCommand: BaseCommand
    {
        public int IntField { get; set; }
        public decimal DecimalField { get; set; }

        public byte[] ToBytes()
        {
            const int messageLength = sizeof(int) + sizeof(decimal);

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write(IntField);
                writer.Write(DecimalField);
                return messageData;
            }
        }

        public static SingleCommand FromBytes(byte[] bytes)
        {
             using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new SingleCommand();

                command.IntField = br.ReadInt32();
                command.DecimalField = br.ReadDecimal();

                return command;
            }
        }
    }
}
