using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApp
{
    public static class Helper
    {
        // Tất cả bên trong đều phải là Static

        public static string RandomString(int len)
        {
            string pattern = "123456789qwertyuiiopasdfghjklzxcvbnm";
            char[] arr = new char[len];
            Random random = new Random();
            for(int i = 0; i < len; i++)
            {
                int idx = random.Next(pattern.Length);
                arr[i] = pattern[idx];
            }

            return string.Join("", arr);
        }

        public static byte[] Hash(string plaintext)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA-512");
            return algorithm.ComputeHash(System.Text.Encoding.ASCII.GetBytes(plaintext)); ;
        }
    }
}
