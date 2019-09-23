using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UserService
{
    public class HashService
    {
        public Tuple<string,string> HashString(string stringToHash)
        {
            HashAlgorithm algorithm = new SHA384Managed();

            var byteValue = Encoding.UTF8.GetBytes(stringToHash);

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[128];
            rng.GetBytes(salt);

            var saltedValue = byteValue.Concat(salt).ToArray();

            var hash = algorithm.ComputeHash(saltedValue);

            return new Tuple<string, string>(Convert.ToBase64String(hash), Convert.ToBase64String(salt)); 
        }

        public Tuple<string, string> HashString(string stringToHash, string salt)
        {
            HashAlgorithm algorithm = new SHA384Managed();

            var byteValue = Encoding.UTF8.GetBytes(stringToHash);

            var byteSalt = Convert.FromBase64String(salt);

            var saltedValue = byteValue.Concat(byteSalt).ToArray();

            var hash = algorithm.ComputeHash(saltedValue);

            return new Tuple<string, string>(Convert.ToBase64String(hash), salt);
        }
    }
}
