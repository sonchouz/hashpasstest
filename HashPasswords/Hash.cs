using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashPasswords
{
    public class Hash
    {
        public static string gethashpass(string pass)
        {
            using (var sha256hash = SHA256.Create())
            {
                byte[] userpass = Encoding.UTF8.GetBytes(pass); 
                byte[] hashpass = sha256hash.ComputeHash(userpass);
                return BitConverter.ToString(hashpass).Replace("-", "");
            }
        }
    }
}
