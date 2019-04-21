using System.IO;
using TcpNetwork.Utils;

namespace TcpNetwork.Commands
{
    public struct LeaveRoomCommand : BaseCommand
    {
        public SignInCommand signin { get; set; } // whoami

        public string roomName { get; set; }
        public int roomNameLength => roomName.Length;

        public byte[] ToBytes()
        {
            byte[] roomNameBytes = CommandUtils.GetBytes(roomName);

            int messageLength = sizeof(int) + roomNameLength;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write(roomNameLength);
                writer.Write(roomNameBytes);

                return messageData;
            }
        }

        public static LeaveRoomCommand FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new LeaveRoomCommand();

                var signin = SignInCommand.FromStream(ms);
                command.signin = signin;

                var roomNameLength = br.ReadInt32();
                command.roomName = CommandUtils.GetString(br.ReadBytes(roomNameLength));

                return command;
            }
        }
    }
}
