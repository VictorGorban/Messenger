using System.IO;
using System.Windows.Forms;
using TcpNetwork.Commands;
using TcpNetwork.Enums;
using TcpNetwork.Network;

namespace TcpClient
{
    public partial class MainForm : Form
    {
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

            CommandSender.SendCommandToServer(ServerAddressBox.Text, stringCommand, CommandType.SendMessage);
        }

        private void MessageHandler_OnMessageAccepted()
        {
            MessageBox.Show("Server received the message and sent the answer");
        }

        private void browseButton_Click(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void sendFileButton_Click(object sender, System.EventArgs e)
        {
            var singleCommand = new FileCommand
            {
                FileName = Path.GetFileName(pathToFileTextBox.Text),
                FileBytes = File.ReadAllBytes(pathToFileTextBox.Text)
            };

            CommandSender.SendCommandToServer(ServerAddressBox.Text, singleCommand, CommandType.File);
        }

        private void sendUseComanndButton_Click(object sender, System.EventArgs e)
        {
            var saveUserCommand = new SaveUserCommand
            {
                FirstName = firstNameTextBox.Text,
                SecondName = secondNameTextBox.Text
            };

            CommandSender.SendCommandToServer(ServerAddressBox.Text, saveUserCommand, CommandType.SaveUser);
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
    }
}
