using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Gradebook.Business.Helpers
{
    public static class MD5Helper
    {
        public static string GetPasswordHash(string password)
        {
            using (var hasher = MD5.Create())
            {
                byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(password));
                var hash = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    hash.Append(data[i].ToString("x2", CultureInfo.InvariantCulture));
                }

                return hash.ToString();
            }
        }
    }
}
