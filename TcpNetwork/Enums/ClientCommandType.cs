namespace TCPNetwork.Enums
{
    public enum ClientCommandType : int
    {
        Signup,
        Signin,

        EnterRoom,
        LeaveRoom,

        SendChatMessage, // отправить сообщение в чате
    }
}
