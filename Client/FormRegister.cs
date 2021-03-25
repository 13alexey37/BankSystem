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
    public partial class FormRegister : Form
    {
        private ClientApi api;

        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            api = ClientApi.GetInstance();
        }

        private async void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (textBoxFio.Text.Length == 0)
            {
                MessageBox.Show("Логин не может быть пустым.");
                return;
            }
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
            if (textBoxPass.Text != textBoxPassConfirm.Text)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }
            try
            {
                User user = new User()
                {
                    Fio = textBoxFio.Text,
                    Login = textBoxLogin.Text,
                    Password = Utils.GetSHA256Hash(textBoxPass.Text)
                };

                bool registerResult = await api.RegisterUserAsync(user);

                if (registerResult == false)
                {
                    MessageBox.Show("Логин занят.");
                    return;
                }
                MessageBox.Show("Регистрация прошла успешно. Залогиньтесь.");
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка соединения с сервером. Попробуйте позже. текст ошибки: " + exception);
            }
        }
    }
}
