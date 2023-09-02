using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace XProject.Database.SchemaCompare.SQLServer.XValue
{
    public class HashValue
    {
        public static string SHA512Hash(params object[] source)
        {
            var result = string.Empty;

            using (var hash = SHA512.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(
                    string.Join(string.Empty, source.Select(x => x.ToString()))
                );
                var hashing = BitConverter.ToString(hash.ComputeHash(buffer));
                result = Regex.Replace(hashing, "[^0-9A-Za-z]", string.Empty, RegexOptions.IgnoreCase).Trim().ToLower();
                hash.Clear();
            }

            return result;
        }
    }
}
