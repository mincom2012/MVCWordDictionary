using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace MVCWordDictionary
{
    public class Common
    {
        public static string GenerateHashWithSalt(string password, string salt) {
            string sHashWithSalt = password + salt;
            byte[] saltHashBytes = Encoding.UTF8.GetBytes(sHashWithSalt);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltHashBytes);
            return Convert.ToBase64String(hash);
        }

    }
}