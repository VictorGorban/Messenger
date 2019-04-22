using Newtonsoft.Json;
using System.IO;
using TCPNetwork.Utils;

namespace TCPNetwork.ClientCommandTypes
{
    public class SignInCommand : BaseCommand
    {
        public string Login { get; set; }
        //public int LoginLength => Login.Length;

        public string Password { get; set; }
        //public int PasswordLength => Password.Length;

        // todo: превратить сложный ToBytes в сериализацию Json.
        // todo: потестить выходной формат, и способ парсинга.
        // Но все равно это после пола)

        public byte[] ToBytes()
        {
            // все это превращается в сериализацию и кол-ва байт сериализованного объекта.
            return this.JsonSerializeToBytes();


            //byte[] loginBytes = CommandUtils.GetBytes(Login);
            //byte[] passwordBytes = CommandUtils.GetBytes(Password);

            //int messageLength = sizeof(int) * 2 + LoginLength + PasswordLength;

            //var messageData = new byte[messageLength];
            //using (var stream = new MemoryStream(messageData))
            //{
            //    var writer = new BinaryWriter(stream);
            //    writer.Write(LoginLength);
            //    writer.Write(loginBytes);

            //    writer.Write(PasswordLength);
            //    writer.Write(passwordBytes);

            //    return messageData;
            //}
        }

        public static SignInCommand FromBytes(byte[] bytes)
        {
            return bytes.JsonDeserialize<SignInCommand>();

            //using (var ms = new MemoryStream(bytes))
            //{
            //    var br = new BinaryReader(ms);
            //    var command = new SignInCommand();

            //    var loginLength = br.ReadInt32();
            //    command.Login = CommandUtils.GetString(br.ReadBytes(loginLength));

            //    var passwordLength = br.ReadInt32();
            //    command.Password = CommandUtils.GetString(br.ReadBytes(passwordLength));

            //    return command;
            //}
        }

        //public static SignInCommand FromStream(Stream stream)
        //{
        //        var br = new BinaryReader(stream);
        //        var command = new SignInCommand();

        //        var loginLength = br.ReadInt32();
        //        command.Login = CommandUtils.GetString(br.ReadBytes(loginLength));

        //        var passwordLength = br.ReadInt32();
        //        command.Password = CommandUtils.GetString(br.ReadBytes(passwordLength));

        //        return command;
        //}
    }
}
