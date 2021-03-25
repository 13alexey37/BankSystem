using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferDataClassLibrary.Entities;
using MySql.Data.MySqlClient;

namespace Server.Data
{
    class TableUsers
    {
        private string connectionString;

        public TableUsers(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Insert(User user)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText =
                            $"INSERT INTO `users`(`fio`,`login`,`pass`,`balance`) VALUES ('{user.Fio}','{user.Login}','{user.Password}',0)";
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

        public User SelectByLoginAndPassword(string login, string password)
        {
            try
            {
                User user = null;

                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText =
                            $"SELECT `id`, `fio`, `balance` FROM `users` WHERE `login` = '{login}' and `pass` = '{password}'";
                        MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                        if (mySqlDataReader.Read())
                        {
                            user = new User()
                            {
                                Id = mySqlDataReader.GetInt32("id"),
                                Fio = mySqlDataReader.GetString("fio"),
                                Balance = mySqlDataReader.GetInt32("balance")
                            };
                        }
                    }
                    mySqlConnection.Close();
                }

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckLogin(string login)
        {
            try
            {
                bool exist = false;

                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText =
                            $"SELECT `id` FROM `users` WHERE `login`='{login}'";
                        MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                        exist = mySqlDataReader.HasRows;
                    }
                    mySqlConnection.Close();
                }

                return exist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<User> GetAllUsersWithoutMe(int explitId)
        {
            try
            {
                List<User> users = new List<User>();

                bool exist = false;

                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText =
                            $"SELECT `id`,`fio` FROM `users` WHERE `id` != '{explitId}'";
                        MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                        while (mySqlDataReader.Read())
                        {
                            users.Add(new User()
                            {
                                Id = mySqlDataReader.GetInt32("id"),
                                Fio = mySqlDataReader.GetString("fio")
                            });
                        }
                    }
                    mySqlConnection.Close();
                }

                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetMyBalance(int id)
        {
            try
            {
                int balance = 0;
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText =
                            $"SELECT `balance` FROM `users` WHERE `id` = '{id}'";

                        balance = Convert.ToInt32(mySqlCommand.ExecuteScalar());
                    }
                    mySqlConnection.Close();
                }
                return balance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void IncreaseBalance(int id, int money)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText =
                            $"UPDATE `users` SET `balance`=`balance`+{money} WHERE `id`={id}";
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

        public void DecreaseBalance(int id, int money)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.CommandText =
                            $"UPDATE `users` SET `balance`=`balance`-{money} WHERE `id`={id}";
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
    }
}
