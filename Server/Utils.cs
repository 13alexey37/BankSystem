using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Utils
    {
        public static void Log(string text)
        {
            Console.WriteLine(($"{DateTime.Now}: "+text));
        }
    }
}
