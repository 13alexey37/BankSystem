using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    class DBManager
    {
        private static DBManager instance;

        public static DBManager GetInstance() => instance ?? (instance = new DBManager());

        public TableUsers TableUsers { get; private set; }
        public TableTransactions TableTransactions { get; private set; }

        private DBManager()
        {
            string connectionString = "Server=localhost;User=root;Password=1234;Database=bank_system";

            TableUsers = new TableUsers(connectionString);
            TableTransactions = new TableTransactions(connectionString);
        }
    }
}
