using System.IO;
using System.Windows.Forms;
using TCPNetwork.Commands;
using TCPNetwork.Enums;
using TCPNetwork.Network;

namespace TcpClient
{
    public partial class MainForm : Form
    {
        //todo где-то надо реализовать периодический запрос данных. С обновлением. Ну таймер, чего уж тут


        public MainForm()
        {
            InitializeComponent();
            MessageHandler.OnMessageAccepted += MessageHandler_OnMessageAccepted;
        }

        private void sendStringCommandButton_Click(object sender, System.EventArgs e)
        {
            var stringCommand = new StringCommand
            {
                StringField = stringCommandTextBox.Text
            };

            CommandSender.SendCommandToServer(Settings.ServerAddress, stringCommand, CommandType.SendChatMessage);
        }

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
            Settings.UserPassword = (sender as TextBox).Text;

        }

        private void ClearNotificationsBoxButton_Click(object sender, System.EventArgs e)
        {
            NotificationsBox.Clear();
        }
    }
}
