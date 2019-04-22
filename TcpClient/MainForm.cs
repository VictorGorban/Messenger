using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using TCPNetwork.ClientCommandTypes;
using TCPNetwork.Enums;
using TCPNetwork.Network;
using TCPNetwork.Utils;

namespace TcpClientApp
{
    public partial class MainForm : Form
    {
        //todo где-то надо реализовать периодический запрос данных. С обновлением. Ну таймер, чего уж тут
        //CommandSender commandSender;
        CommandListener listener;

        public MainForm()
        {
            InitializeComponent();
            listener = new CommandListener(HandleServerResponse);
        }

        //private void sendStringCommandButton_Click(object sender, System.EventArgs e)
        //{
        //    var stringCommand = new StringCommand
        //    {
        //        StringField = stringCommandTextBox.Text
        //    };

        //    CommandSender.SendCommandToServer(Settings.ServerAddress, stringCommand, CommandType.SendChatMessage);
        //}

        private void MessageHandler_OnMessageAccepted()
        {
            MessageBox.Show("Server received the message and sent the answer");
        }


        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void SignupButton_Click(object sender, System.EventArgs e)
        {
            // todo: Отправлять команды и обрабатывать ответы
        }

        private void ServerAddressBox_TextChanged(object sender, System.EventArgs e)
        {
            Settings.ServerAddress = (sender as TextBox).Text;
        }

        private void UsernameBox_TextChanged(object sender, System.EventArgs e)
        {
            Settings.UserName = (sender as TextBox).Text;

        }

        private void PasswordBox_TextChanged(object sender, System.EventArgs e)
        {
            Settings.UserPassword = (sender as TextBox).Text.EncryptSHA512();
        }

        private void ClearNotificationsBoxButton_Click(object sender, System.EventArgs e)
        {
            NotificationsBox.Clear();
        }








        #region Handler
        private delegate BaseCommand CommandFromBytes(byte[] bytes);
        private delegate BaseCommand CommandFromStream(Stream stream);

        private readonly Dictionary<ClientCommandType, CommandFromBytes> commandsFromBytes = new Dictionary<ClientCommandType, CommandFromBytes>();
        private readonly Dictionary<ClientCommandType, CommandFromStream> commandsFromStream = new Dictionary<ClientCommandType, CommandFromStream>();



        public void HandleServerResponse(object server)
        {
            /** Алгоритм:
             *  Определить тип сообщения
             *  в зависимости от этого, 
             *      распарсить байты сообщения (подойдет Dictionary с методами FromStream.)
             *      предпринять действия
             *      отправить ответ.
             *      
             *  
             *  
             *  
             */


            var tcpClient = (System.Net.Sockets.TcpClient)server;
            tcpClient.ReceiveTimeout = 3;
            NetworkStream clientStream = tcpClient.GetStream();

            var ms = new MemoryStream();
            var binaryWriter = new BinaryWriter(ms);

            var messageLengthBytes = new byte[4];
            var messageBytes = new byte[tcpClient.ReceiveBufferSize];
            int readCount;
            int totalReadMessageBytes = 0;

            clientStream.Read(messageLengthBytes, 0, sizeof(int));
            int messageLength = CommandUtils.BytesToInt(messageLengthBytes);

            while ((readCount = clientStream.Read(messageBytes, 0, tcpClient.ReceiveBufferSize)) != 0)
            {
                binaryWriter.Write(messageBytes, 0, readCount);
                totalReadMessageBytes += readCount;
                if (totalReadMessageBytes >= messageLength)
                    break;
            }

            if (ms.Length > 0)
            {
                ParseResponseBytes(ms.ToArray());
            }

            void ParseResponseBytes(byte[] bytes)
            {
                if (bytes.Length >= ClientCommandHeader.GetLength())
                {
                    
                }
            }
        }
        #endregion


        #region Sender
        public bool SendCommandToServer(string serverIp, BaseCommand command, ClientCommandType clientCommandType)
        {
            var commandHeader = new ClientCommandHeader
            {
                Type = clientCommandType
            };

            var client = new TcpClient();
            try
            {
                client.Connect(serverIp, Settings.ServerPort);

                // + составить байты из ClientHeader и сериализации команды (+prepend with length)
                byte[] messageBytes = CommandUtils.ConcatByteArrays(commandHeader.ToBytes(), command.ToBytes());
                byte[] messageBytesWithLength = CommandUtils.PrependLengthBytes(messageBytes);
                
                // + отправить байты в NetworkStream
                NetworkStream networkStream = client.GetStream();
                networkStream.Write(messageBytesWithLength, 0, messageBytesWithLength.Length);

                // + Обработать ответ
                HandleServerResponse(client);
            }
            catch (SocketException)
            {
                Error("Cannot sent command to server");
                return false;
            }

            return true;
        }
        #endregion


        public void Error(string errorMessage)
        {
            MessageBox.Show(errorMessage,"Error");
        }

        private void CheckSettingsButton_Click(object sender, System.EventArgs e)
        {
            var signinCommand = new SignInCommand()
            {
                Login = Settings.UserName,
                Password = Settings.UserPassword
            };

            var bytes = signinCommand.JsonSerializeToBytes();

            var command1 = bytes.JsonDeserialize<SignInCommand>();




            // try    sendCommandToServer (signin)
        }
    }
}
