namespace TCPNetwork.Enums
{
    public enum CommandType : int
    {
        Signup,
        Signin,

        EnterRoom,
        LeaveRoom,

        SendChatMessage, // отправить сообщение в чате

        ServerResponse,
    }
}
