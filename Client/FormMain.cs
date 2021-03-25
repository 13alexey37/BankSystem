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
    public partial class FormMain : Form
    {
        private ClientApi api;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FillRichTextBoxTransferHistory(List<Transaction> transactions, int user1Id, int user2Id, string user1Fio, string user2Fio)
        {
            richTextBoxTransferHistory.Clear();

            foreach (Transaction transaction in transactions)
            {
                string fioFrom, fioTo;

                if (transaction.UserFrom.Id==user1Id)
                {
                    fioFrom = user1Fio;
                    fioTo = user2Fio;
                }
                else
                {
                    fioFrom = user2Fio;
                    fioTo = user1Fio;
                }

                richTextBoxTransferHistory.Text += "Дата перевода: "+ transaction.Dt + "\n";
                richTextBoxTransferHistory.Text += "Отправитель: " + fioFrom + "\n";
                richTextBoxTransferHistory.Text += "Получатель: " + fioTo + "\n";
                richTextBoxTransferHistory.Text += "Сумма перевода: " + transaction.Money + "\n";
                richTextBoxTransferHistory.Text += "__________________________\n";
            }
        }


        private async void FormMain_Load(object sender, EventArgs e)
        {
            api = ClientApi.GetInstance();

            labelFio.Text = GlobalData.User.Fio;
            labelBallance.Text = GlobalData.User.Balance.ToString();

            try
            {
                listBoxUsers.DataSource = await api.GetAllUsersWithoutMeAsync(GlobalData.User.Id);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка соединения с сервером. Попробуйте позже. текст ошибки: " + exception);
            }
        }

        private async void timerUpdateMyBalance_Tick(object sender, EventArgs e)
        {

            labelBallance.Text = (await api.GetMyBalanceAsync(GlobalData.User.Id)).ToString();
        }

        private async void buttonIncreaseBalance_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxIncreaseBalance.Text == "")
            {
                MessageBox.Show("Ошибка. Введите сумму пополнения.");
                return;
            }

            try
            {
                int money = int.Parse(maskedTextBoxIncreaseBalance.Text);
                Transaction transaction = new Transaction()
                {
                    Money = money,
                    UserFrom = new User() {Id = GlobalData.User.Id},
                    UserTo = new User() {Id = GlobalData.User.Id}
                };

                bool increaseResult = await api.UpMyBalanceAsync(transaction);
                if (increaseResult == true)
                {
                    labelBallance.Text = (await api.GetMyBalanceAsync(GlobalData.User.Id)).ToString();

                    maskedTextBoxIncreaseBalance.Clear();

                    MessageBox.Show("Баланс успешно пополнен");
                }
                else
                {
                    MessageBox.Show("Ошибка пополнения баланса");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка соединения с сервером. Попробуйте позже. текст ошибки: " + exception);
            }

        }

        private async void buttonTransfer_Click(object sender, EventArgs e)
        {
            if (textBoxUserToIdToId.Text == "")
            {
                MessageBox.Show("Ошибка. Выберите пользователя для перевода.");
                return;
            }

            if (maskedTextBoxTransferMoney.Text == "")
            {
                MessageBox.Show("Ошибка. Введите сумму пополнения.");
                return;
            }

            try
            {
                int money = int.Parse(maskedTextBoxTransferMoney.Text);
                if (money> await api.GetMyBalanceAsync(GlobalData.User.Id))
                {
                    MessageBox.Show("У вас недостаточно денег для перевода.");
                    return;
                }

                int idUserTo = int.Parse(textBoxUserToIdToId.Text);
                Transaction transaction = new Transaction()
                {
                    Money = money,
                    UserFrom = new User() { Id = GlobalData.User.Id },
                    UserTo = new User() { Id = idUserTo }
                };

                bool transactionResult = await api.MakeTransactionFromUserToUserAsync(transaction);
                if (transactionResult == true)
                {
                    labelBallance.Text = (await api.GetMyBalanceAsync(GlobalData.User.Id)).ToString();

                    List<Transaction> trans =
                        await api.GetMyTransactionsHistoryWithAnotherUserAsync(GlobalData.User.Id, idUserTo);

                    FillRichTextBoxTransferHistory(trans, GlobalData.User.Id, idUserTo, labelFio.Text, labelSelectedUserToFio.Text);

                    maskedTextBoxTransferMoney.Clear();
                    textBoxUserToIdToId.Clear();

                    MessageBox.Show("Перевод успешно выполнен");
                }
                else
                {
                    MessageBox.Show("Ошибка перевода");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка соединения с сервером. Попробуйте позже. текст ошибки: " + exception);
            }
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = listBoxUsers.SelectedItem as User;

            if (user == null)
            {
                return;
            }

            textBoxUserToIdToId.Text = user.Id.ToString();
            labelSelectedUserToFio.Text = user.Fio;
        }

        private async void buttonGetTransferHistory_Click(object sender, EventArgs e)
        {
            if (textBoxUserToIdToId.Text == "")
            {
                MessageBox.Show("Ошибка. Выберите пользователя для получения истории.");
                return;
            }

            int idUserTo = int.Parse(textBoxUserToIdToId.Text);

            List<Transaction> trans =
                await api.GetMyTransactionsHistoryWithAnotherUserAsync(GlobalData.User.Id, idUserTo);

            FillRichTextBoxTransferHistory(trans, GlobalData.User.Id, idUserTo, labelFio.Text, labelSelectedUserToFio.Text);
        }
    }
}
