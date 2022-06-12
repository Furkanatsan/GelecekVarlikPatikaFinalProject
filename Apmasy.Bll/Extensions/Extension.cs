using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Bll.Extensions
{
    public static class Extension
    {
        //kullanucuya ransom  parola oluşturma
        public static string GeneratePassword(int passLength)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder buildPass = new StringBuilder();
            Random randomVal = new Random();
            while (0 < passLength--)
            {
                buildPass.Append(chars[randomVal.Next(chars.Length)]);
            }
            return buildPass.ToString();
        }
    }
}
