using System.IO;
using TcpNetwork.Utils;

namespace TcpNetwork.Commands
{
    public class FileCommand: BaseCommand
    {
        private int FileNameLength { get; set; }
        public string FileName { get; set; }

        private int FileBytesCount { get; set; }
        public byte[] FileBytes { get; set; }

        public byte[] ToBytes()
        {
            byte[] fileNameBytes = CommandUtils.GetBytes(FileName);
            FileNameLength = fileNameBytes.Length;

            FileBytesCount = FileBytes.Length;
            int messageLength = sizeof(int) * 2 + FileBytesCount + FileNameLength;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);

                writer.Write(FileNameLength);
                writer.Write(fileNameBytes);

                writer.Write(FileBytesCount);
                writer.Write(FileBytes);

                return messageData;
            }
        }

        public static FileCommand FromBytes(byte[] bytes)
        {
             using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new FileCommand();

                command.FileNameLength = br.ReadInt32();
                command.FileName = CommandUtils.GetString(br.ReadBytes(command.FileNameLength));

                command.FileBytesCount = br.ReadInt32();
                command.FileBytes = br.ReadBytes(command.FileBytesCount);

                return command;
            }
        }
    }
}
