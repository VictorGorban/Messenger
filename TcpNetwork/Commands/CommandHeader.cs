using System.IO;
using TcpNetwork.Enums;

namespace TcpNetwork.Commands
{
    public class CommandHeader
    {
        public CommandType Type { get; set; }

        public static int GetLength()
        {
            return sizeof(int);
        }

        public static  CommandHeader FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var header = new CommandHeader();

                header.Type = (CommandType) br.ReadInt32();

                return header;
            }
        }

        public  byte[] ToBytes()
        {
            var data = new byte[GetLength()];

            using (var stream = new MemoryStream(data))
            {
                using( var writer = new BinaryWriter(stream))
                {
                    writer.Write((int)Type);
                }
  
                return data;
            }

        }
    }
}
