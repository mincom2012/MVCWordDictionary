using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using MVCWordDictionary.Enumeration;

namespace MVCWordDictionary
{
    public class CommonHelper
    {
        public static string GenerateHashWithSalt(string password, string salt)
        {
            string sHashWithSalt = password + salt;
            byte[] saltHashBytes = Encoding.UTF8.GetBytes(sHashWithSalt);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltHashBytes);
            return Convert.ToBase64String(hash);
        }

        public static string DisplayImageNewsThumb(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                return "";
            }

            var imagePath = ConfigurationManager.AppSettings["ImageNews_Thumb"].ToString();
            var filePath = VirtualPathUtility.ToAbsolute(imagePath + imageName);
            return filePath;
        }

        public static string ConvertValueToStringEnum(Type type, int value)
        {
            var typeName = Enum.GetName(type, value);
            return EnumResource.ResourceManager.GetString(type.Name + "_" + typeName);
        }


    }
}