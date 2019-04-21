namespace TcpClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ServerAddressBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Text = new System.Windows.Forms.Label();
            this.stringCommandTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sendStringCommandButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NotificationsBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MessagesBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.SendMessageBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CheckSettingsButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SignupButton = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ClearNotificationsBoxButton = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClearNotificationsBoxButton)).BeginInit();
            this.SuspendLayout();
            // 
            // ServerAddressBox
            // 
            this.ServerAddressBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerAddressBox.Location = new System.Drawing.Point(172, 16);
            this.ServerAddressBox.Name = "ServerAddressBox";
            this.ServerAddressBox.Size = new System.Drawing.Size(131, 29);
            this.ServerAddressBox.TabIndex = 0;
            this.ServerAddressBox.Text = "127.0.0.1";
            this.ServerAddressBox.TextChanged += new System.EventHandler(this.ServerAddressBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server address:";
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text.Location = new System.Drawing.Point(9, 29);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(41, 21);
            this.Text.TabIndex = 3;
            this.Text.Text = "Text:";
            // 
            // stringCommandTextBox
            // 
            this.stringCommandTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringCommandTextBox.Location = new System.Drawing.Point(46, 26);
            this.stringCommandTextBox.Name = "stringCommandTextBox";
            this.stringCommandTextBox.Size = new System.Drawing.Size(290, 29);
            this.stringCommandTextBox.TabIndex = 2;
            this.stringCommandTextBox.Text = "Hello";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sendStringCommandButton);
            this.groupBox1.Controls.Add(this.stringCommandTextBox);
            this.groupBox1.Controls.Add(this.Text);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 436);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "String Command";
            // 
            // sendStringCommandButton
            // 
            this.sendStringCommandButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendStringCommandButton.Location = new System.Drawing.Point(202, 52);
            this.sendStringCommandButton.Name = "sendStringCommandButton";
            this.sendStringCommandButton.Size = new System.Drawing.Size(134, 32);
            this.sendStringCommandButton.TabIndex = 5;
            this.sendStringCommandButton.Text = "Send";
            this.sendStringCommandButton.UseVisualStyleBackColor = true;
            this.sendStringCommandButton.Click += new System.EventHandler(this.sendStringCommandButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ClearNotificationsBoxButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.NotificationsBox);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 51);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "=>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // NotificationsBox
            // 
            this.NotificationsBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotificationsBox.Location = new System.Drawing.Point(75, 3);
            this.NotificationsBox.Multiline = true;
            this.NotificationsBox.Name = "NotificationsBox";
            this.NotificationsBox.Size = new System.Drawing.Size(219, 45);
            this.NotificationsBox.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ServerAddressBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(8, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 52);
            this.panel2.TabIndex = 13;
            // 
            // MessagesBox
            // 
            this.MessagesBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessagesBox.Location = new System.Drawing.Point(4, 29);
            this.MessagesBox.Multiline = true;
            this.MessagesBox.Name = "MessagesBox";
            this.MessagesBox.Size = new System.Drawing.Size(308, 235);
            this.MessagesBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Messages";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(328, 359);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SendMessageButton);
            this.tabPage1.Controls.Add(this.SendMessageBox);
            this.tabPage1.Controls.Add(this.MessagesBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(320, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Actions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendMessageButton.Location = new System.Drawing.Point(251, 270);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(63, 49);
            this.SendMessageButton.TabIndex = 11;
            this.SendMessageButton.Text = "Go";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            // 
            // SendMessageBox
            // 
            this.SendMessageBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendMessageBox.Location = new System.Drawing.Point(6, 271);
            this.SendMessageBox.Multiline = true;
            this.SendMessageBox.Name = "SendMessageBox";
            this.SendMessageBox.Size = new System.Drawing.Size(239, 48);
            this.SendMessageBox.TabIndex = 15;
            this.SendMessageBox.Text = "Enter room1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CheckSettingsButton);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(320, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CheckSettingsButton
            // 
            this.CheckSettingsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckSettingsButton.Location = new System.Drawing.Point(87, 193);
            this.CheckSettingsButton.Name = "CheckSettingsButton";
            this.CheckSettingsButton.Size = new System.Drawing.Size(134, 32);
            this.CheckSettingsButton.TabIndex = 11;
            this.CheckSettingsButton.Text = "Check";
            this.CheckSettingsButton.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SignupButton);
            this.panel3.Controls.Add(this.PasswordBox);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.UsernameBox);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(8, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(306, 110);
            this.panel3.TabIndex = 14;
            // 
            // SignupButton
            // 
            this.SignupButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupButton.Location = new System.Drawing.Point(172, 75);
            this.SignupButton.Name = "SignupButton";
            this.SignupButton.Size = new System.Drawing.Size(134, 32);
            this.SignupButton.TabIndex = 15;
            this.SignupButton.Text = "SignUp";
            this.SignupButton.UseVisualStyleBackColor = true;
            this.SignupButton.Click += new System.EventHandler(this.SignupButton_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordBox.Location = new System.Drawing.Point(172, 42);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '#';
            this.PasswordBox.Size = new System.Drawing.Size(131, 29);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.Text = "1234";
            this.PasswordBox.UseSystemPasswordChar = true;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "Password";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameBox.Location = new System.Drawing.Point(172, 16);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(131, 29);
            this.UsernameBox.TabIndex = 0;
            this.UsernameBox.Text = "VictorGorban1";
            this.UsernameBox.TextChanged += new System.EventHandler(this.UsernameBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "Username";
            // 
            // ClearNotificationsBoxButton
            // 
            this.ClearNotificationsBoxButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClearNotificationsBoxButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearNotificationsBoxButton.Image")));
            this.ClearNotificationsBoxButton.Location = new System.Drawing.Point(297, 8);
            this.ClearNotificationsBoxButton.Name = "ClearNotificationsBoxButton";
            this.ClearNotificationsBoxButton.Size = new System.Drawing.Size(27, 32);
            this.ClearNotificationsBoxButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ClearNotificationsBoxButton.TabIndex = 17;
            this.ClearNotificationsBoxButton.TabStop = false;
            this.ClearNotificationsBoxButton.Click += new System.EventHandler(this.ClearNotificationsBoxButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 538);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClearNotificationsBoxButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ServerAddressBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Text;
        private System.Windows.Forms.TextBox stringCommandTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button sendStringCommandButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox NotificationsBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox MessagesBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SendMessageButton;
        private System.Windows.Forms.TextBox SendMessageBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CheckSettingsButton;
        private System.Windows.Forms.Button SignupButton;
        private System.Windows.Forms.PictureBox ClearNotificationsBoxButton;
    }
}

