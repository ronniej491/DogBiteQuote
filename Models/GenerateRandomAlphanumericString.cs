using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBQWebsite.Models
{
    public class GenerateRandomAlphanumeric
    {
        private static Random random = new Random();
        public static string GenerateRandomAlphanumericString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
