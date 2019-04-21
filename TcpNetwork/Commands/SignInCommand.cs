using System.IO;
using TCPNetwork.Utils;

namespace TCPNetwork.Commands
{
    public class SignInCommand : BaseCommand
    {
        public string Login { get; set; }
        public int LoginLength => Login.Length;

        public string Password { get; set; }
        public int PasswordLength => Password.Length;

        public byte[] ToBytes()
        {
            byte[] loginBytes = CommandUtils.GetBytes(Login);
            byte[] passwordBytes = CommandUtils.GetBytes(Password);

            int messageLength = sizeof(int) * 2 + LoginLength + PasswordLength;

            var messageData = new byte[messageLength];
            using (var stream = new MemoryStream(messageData))
            {
                var writer = new BinaryWriter(stream);
                writer.Write(LoginLength);
                writer.Write(loginBytes);

                writer.Write(PasswordLength);
                writer.Write(passwordBytes);

                return messageData;
            }
        }

        public static SignInCommand FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var br = new BinaryReader(ms);
                var command = new SignInCommand();

                var loginLength = br.ReadInt32();
                command.Login = CommandUtils.GetString(br.ReadBytes(loginLength));

                var passwordLength = br.ReadInt32();
                command.Password = CommandUtils.GetString(br.ReadBytes(passwordLength));

                return command;
            }
        }

        public static SignInCommand FromStream(Stream stream)
        {
                var br = new BinaryReader(stream);
                var command = new SignInCommand();

                var loginLength = br.ReadInt32();
                command.Login = CommandUtils.GetString(br.ReadBytes(loginLength));

                var passwordLength = br.ReadInt32();
                command.Password = CommandUtils.GetString(br.ReadBytes(passwordLength));

                return command;
        }
    }
}
