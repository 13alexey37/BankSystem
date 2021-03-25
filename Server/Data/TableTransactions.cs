using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TransferDataClassLibrary.Entities;

namespace Server.Data
{
    class TableTransactions
    {
        private string connectionString;

        public TableTransactions(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Insert(Transaction transaction)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText = $"INSERT INTO `transactions`(`dt`,`user_id_from`,`user_id_to`,`money`) VALUES('{transaction.Dt.ToString("yyyy-MM-dd HH:mm:ss")}',{transaction.UserFrom.Id},{transaction.UserTo.Id},{transaction.Money})";
                        mySqlCommand.ExecuteNonQuery();
                    }
                    mySqlConnection.Close();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Transaction> GetAllTransactionBetweenUsers(int user1Id, int user2Id)
        {
            try
            {
                List<Transaction> transactions = new List<Transaction>();

                bool exist = false;

                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText =
                            $"SELECT * FROM `transactions` WHERE `user_id_from` = {user1Id} AND `user_id_to`={user2Id} OR `user_id_from` = {user2Id} AND `user_id_to`={user1Id}";
                        MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                        while (mySqlDataReader.Read())
                        {
                            transactions.Add(new Transaction()
                            {
                                Dt = mySqlDataReader.GetDateTime("dt"),
                                UserFrom = new User() { Id = mySqlDataReader.GetInt32("user_id_from")},
                                UserTo = new User() { Id = mySqlDataReader.GetInt32("user_id_to") },
                                Money = mySqlDataReader.GetInt32("money")
                            });
                        }
                    }
                    mySqlConnection.Close();
                }

                return transactions;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
