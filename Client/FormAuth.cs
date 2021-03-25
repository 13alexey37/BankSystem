using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Api;
using TransferDataClassLibrary.Entities;

namespace Client
{
    public partial class FormAuth : Form
    {
        private ClientApi api;

        public FormAuth()
        {
            InitializeComponent();
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            try
            {
                api = ClientApi.GetInstance();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка соединения с сервером. Приложение будет закрыто");
                Application.Exit();
            }
        }

        private async void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text.Length == 0)
            {
                MessageBox.Show("Логин не может быть пустым.");
                return;
            }
            if (textBoxPass.Text.Length == 0)
            {
                MessageBox.Show("Пароль не может быть пустым.");
                return;
            }
            try
            {
                User user = await api.GetUserByLoginAndPasswordAsync(textBoxLogin.Text, Utils.GetSHA256Hash(textBoxPass.Text));

                if (user==null)
                {
                    MessageBox.Show("Неверный логин/пароль.");
                }

                GlobalData.User = user;
                this.Hide();
                new FormMain().ShowDialog();
                Application.Exit();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка соединения с сервером. Попробуйте позже. текст ошибки: " + exception);
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            new FormRegister().ShowDialog();
        }
    }
}
