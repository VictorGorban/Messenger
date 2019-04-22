using System.IO;
using TCPNetwork.Enums;

namespace TCPNetwork.ClientCommandTypes
{
    public class ClientCommandHeader
    {
        public ClientCommandType Type { get; set; }

        public static int GetLength()
        {
            return sizeof(int);
        }

        public static  ClientCommandHeader FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var header = new ClientCommandHeader();

                header.Type = (ClientCommandType) br.ReadInt32();

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
