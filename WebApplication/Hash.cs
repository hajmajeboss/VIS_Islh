using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication
{
    public class Hash
    {
        public static String GenerateSha1(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA1.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            Console.WriteLine("HASH: " + Sb.ToString());
            return Sb.ToString().ToUpper();
        }

        public static String GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
