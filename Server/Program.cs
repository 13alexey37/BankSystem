using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Engine;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerEngine server = null;
            try
            {
                server = new ServerEngine();
            }
            catch (Exception e)
            {
                Utils.Log("Server error: " + e);
                Console.ReadKey();
                Environment.Exit(0);
            }

            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Utils.Log("Server error: " + e);
                return;
            }

            Console.ReadKey();

        }
    }
}
