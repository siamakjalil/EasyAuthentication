using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Tools
{
    public static class PasswordManager
    {
        public static string GenerateAuthCode(this int val) =>
            Guid.NewGuid().GetHashCode().ToString().Replace("-", string.Empty).Substring(0, val);

        public static string GenerateSalt(this int length)
        {
            try
            {
                var random = new Random();
                var chArray = new char[length];
                const string strChar = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
                for (var index = 0; index <= length - 1; ++index)
                {
                    var getIndex = Convert.ToInt32(
                        (double)strChar.Length *
                        random.NextDouble());
                    chArray[index] = strChar[getIndex];
                }

                return new string(chArray);
            }
            catch (Exception)
            {
                return Guid.NewGuid().ToString().Replace("-", string.Empty)[..length];
            }
        }

        public static string EncodePassword(this string pass, string salt)
        {
            byte[] bytes1 = Encoding.Unicode.GetBytes(pass);
            byte[] bytes2 = Encoding.Unicode.GetBytes(salt);
            byte[] numArray = new byte[bytes2.Length + bytes1.Length];
            Buffer.BlockCopy((Array)bytes2, 0, (Array)numArray, 0, bytes2.Length);
            Buffer.BlockCopy((Array)bytes1, 0, (Array)numArray, bytes2.Length, bytes1.Length);
            return EncodePasswordMd5(Convert.ToBase64String(HashAlgorithm.Create("SHA1").ComputeHash(numArray)));
        }

        public static string EncodePasswordMd5(string pass) =>
            BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(pass)));
    }
}
