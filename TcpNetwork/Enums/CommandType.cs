namespace TcpNetwork.Enums
{
    public enum CommandType : int
    {
        MessageAccepted,

        SendMessage,
        Signin,
        Signup,
        EnterRoom,
        LeaveRoom,

        Single,
        File,
        SaveUser,

    }
}
