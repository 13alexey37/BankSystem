using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferDataClassLibrary.Net
{
    public class RequestWrapper
    {
        public enum CommandEnum
        {
            UsersCreateNew,
            UsersAuthByLoginAndPassword,
            UsersGetAllWithoutMe,
            UsersGetMyBalance,

            TransactionsUpMyBalance,
            TransactionsMakeFromUserToUser,
            TransactionsGetMyHistory
        }

        public CommandEnum Command { get; set; }
        public string Parameters { get; set; }

        public override string ToString()
        {
            return $"\nCommand = {Command}\nParameters = {Parameters}";
        }
    }
}
