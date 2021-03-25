using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferDataClassLibrary.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public User UserFrom { get; set; }
        public User UserTo { get; set; }
        public int Money { get; set; }
    }
}
