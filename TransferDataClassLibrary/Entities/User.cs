using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferDataClassLibrary.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }

        public override string ToString()
        {
            return Fio;
        }
    }
}
