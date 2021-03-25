namespace Client
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelBallance = new System.Windows.Forms.Label();
            this.timerUpdateMyBalance = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.buttonIncreaseBalance = new System.Windows.Forms.Button();
            this.maskedTextBoxIncreaseBalance = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelSelectedUserToFio = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBoxTransferMoney = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBoxTransferHistory = new System.Windows.Forms.RichTextBox();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.textBoxUserToIdToId = new System.Windows.Forms.TextBox();
            this.buttonGetTransferHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(187, 36);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(320, 290);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список доступных пользователей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Здравствуйте,";
            // 
            // labelFio
            // 
            this.labelFio.AutoSize = true;
            this.labelFio.Location = new System.Drawing.Point(13, 30);
            this.labelFio.Name = "labelFio";
            this.labelFio.Size = new System.Drawing.Size(24, 13);
            this.labelFio.TabIndex = 3;
            this.labelFio.Text = "FIO";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 180);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выберите из спска пользователей пользователя, которому хотете перевести деньги.\r\n" +
    "\r\nВведите сумму и нажмите \"перевести\".\r\n\r\nИли\r\n\r\nВведите нужную сумму и нажмите " +
    "\"пополнить баланс\"\r\n\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ваш балланс составляет:";
            // 
            // labelBallance
            // 
            this.labelBallance.AutoSize = true;
            this.labelBallance.Location = new System.Drawing.Point(13, 64);
            this.labelBallance.Name = "labelBallance";
            this.labelBallance.Size = new System.Drawing.Size(46, 13);
            this.labelBallance.TabIndex = 6;
            this.labelBallance.Text = "Balance";
            // 
            // timerUpdateMyBalance
            // 
            this.timerUpdateMyBalance.Enabled = true;
            this.timerUpdateMyBalance.Interval = 5000;
            this.timerUpdateMyBalance.Tick += new System.EventHandler(this.timerUpdateMyBalance_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Пополнить баланс на:";
            // 
            // buttonIncreaseBalance
            // 
            this.buttonIncreaseBalance.Location = new System.Drawing.Point(16, 302);
            this.buttonIncreaseBalance.Name = "buttonIncreaseBalance";
            this.buttonIncreaseBalance.Size = new System.Drawing.Size(165, 23);
            this.buttonIncreaseBalance.TabIndex = 9;
            this.buttonIncreaseBalance.Text = "Пополнить баланс";
            this.buttonIncreaseBalance.UseVisualStyleBackColor = true;
            this.buttonIncreaseBalance.Click += new System.EventHandler(this.buttonIncreaseBalance_Click);
            // 
            // maskedTextBoxIncreaseBalance
            // 
            this.maskedTextBoxIncreaseBalance.Location = new System.Drawing.Point(16, 276);
            this.maskedTextBoxIncreaseBalance.Mask = "000000";
            this.maskedTextBoxIncreaseBalance.Name = "maskedTextBoxIncreaseBalance";
            this.maskedTextBoxIncreaseBalance.Size = new System.Drawing.Size(165, 20);
            this.maskedTextBoxIncreaseBalance.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Выбранный пользователь:";
            // 
            // labelSelectedUserToFio
            // 
            this.labelSelectedUserToFio.AutoSize = true;
            this.labelSelectedUserToFio.Location = new System.Drawing.Point(659, 20);
            this.labelSelectedUserToFio.Name = "labelSelectedUserToFio";
            this.labelSelectedUserToFio.Size = new System.Drawing.Size(27, 13);
            this.labelSelectedUserToFio.TabIndex = 11;
            this.labelSelectedUserToFio.Text = "user";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(510, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Перевод:";
            // 
            // maskedTextBoxTransferMoney
            // 
            this.maskedTextBoxTransferMoney.Location = new System.Drawing.Point(513, 53);
            this.maskedTextBoxTransferMoney.Mask = "000000";
            this.maskedTextBoxTransferMoney.Name = "maskedTextBoxTransferMoney";
            this.maskedTextBoxTransferMoney.Size = new System.Drawing.Size(121, 20);
            this.maskedTextBoxTransferMoney.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(510, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(264, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "История переводов с выбранным пользователем:";
            // 
            // richTextBoxTransferHistory
            // 
            this.richTextBoxTransferHistory.Location = new System.Drawing.Point(513, 93);
            this.richTextBoxTransferHistory.Name = "richTextBoxTransferHistory";
            this.richTextBoxTransferHistory.ReadOnly = true;
            this.richTextBoxTransferHistory.Size = new System.Drawing.Size(261, 203);
            this.richTextBoxTransferHistory.TabIndex = 12;
            this.richTextBoxTransferHistory.Text = "";
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Location = new System.Drawing.Point(649, 51);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(121, 23);
            this.buttonTransfer.TabIndex = 13;
            this.buttonTransfer.Text = "Перевести";
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // textBoxUserToIdToId
            // 
            this.textBoxUserToIdToId.Location = new System.Drawing.Point(407, 10);
            this.textBoxUserToIdToId.Name = "textBoxUserToIdToId";
            this.textBoxUserToIdToId.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserToIdToId.TabIndex = 14;
            // 
            // buttonGetTransferHistory
            // 
            this.buttonGetTransferHistory.Location = new System.Drawing.Point(514, 302);
            this.buttonGetTransferHistory.Name = "buttonGetTransferHistory";
            this.buttonGetTransferHistory.Size = new System.Drawing.Size(120, 23);
            this.buttonGetTransferHistory.TabIndex = 15;
            this.buttonGetTransferHistory.Text = "История переводов";
            this.buttonGetTransferHistory.UseVisualStyleBackColor = true;
            this.buttonGetTransferHistory.Click += new System.EventHandler(this.buttonGetTransferHistory_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 331);
            this.Controls.Add(this.buttonGetTransferHistory);
            this.Controls.Add(this.textBoxUserToIdToId);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.richTextBoxTransferHistory);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelSelectedUserToFio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBoxTransferMoney);
            this.Controls.Add(this.maskedTextBoxIncreaseBalance);
            this.Controls.Add(this.buttonIncreaseBalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelBallance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelFio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxUsers);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelBallance;
        private System.Windows.Forms.Timer timerUpdateMyBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonIncreaseBalance;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxIncreaseBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelSelectedUserToFio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTransferMoney;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBoxTransferHistory;
        private System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.TextBox textBoxUserToIdToId;
        private System.Windows.Forms.Button buttonGetTransferHistory;
    }
}