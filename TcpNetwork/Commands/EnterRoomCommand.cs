using System.IO;
using TcpNetwork.Utils;

namespace TcpNetwork.Commands
{
    public class EnterRoomCommand : BaseCommand
    {
        public SignInCommand signin { get; set; } // whoami

        public string RoomName { get; set; }
        public int RoomNameLength => RoomName.Length;

        public string Password { get; set; }
        public int PasswordLength => Password.Length;

        public byte[] ToBytes()
        {
            byte[] signinBytes = signin.ToBytes();

            byte[] roomNameBytes = CommandUtils.GetBytes(RoomName);
            byte[] passwordBytes = CommandUtils.GetBytes(Password);

            int messageLength = signinBytes.Length + sizeof(int) * 2 + roomNameBytes.Length + passwordBytes.Length;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write(signinBytes);
                writer.Write(RoomNameLength);
                writer.Write(roomNameBytes);

                writer.Write(PasswordLength);
                writer.Write(passwordBytes);

                return messageData;
            }
        }

        public static EnterRoomCommand FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new EnterRoomCommand();

                var signin = SignInCommand.FromStream(ms);
                command.signin = signin;

                var roomNameLength = br.ReadInt32();
                command.RoomName = CommandUtils.GetString(br.ReadBytes(roomNameLength));

                var passwordLength = br.ReadInt32();
                command.Password = CommandUtils.GetString(br.ReadBytes(passwordLength));

                return command;
            }
        }
    }
}
