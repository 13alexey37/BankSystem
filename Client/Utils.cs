using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Utils
    {
        public static string GetSHA256Hash(string textData)
        {
            using (SHA256 hashFunc = SHA256.Create())
            {
                byte[] bytes = hashFunc.ComputeHash(Encoding.UTF8.GetBytes(textData));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
                
            }
        }
    }
}
