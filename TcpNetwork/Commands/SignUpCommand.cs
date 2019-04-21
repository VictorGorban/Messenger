using System.IO;
using TcpNetwork.Utils;

namespace TcpNetwork.Commands
{
    public class SignUpCommand : SignInCommand
    {
        public static new SignUpCommand FromBytes(byte[] bytes)
        {
            return (SignUpCommand)SignInCommand.FromBytes(bytes);
        }
    }
}
