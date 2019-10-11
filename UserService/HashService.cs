using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UserService
{
    public class HashService
    {
        private readonly HashAlgorithm _hashAlgorithm;
        private readonly RandomNumberGenerator _randomNumberGenerator;

        public HashService(HashAlgorithm hashAlgorithm, RandomNumberGenerator randomNumberGenerator)
        {
            _hashAlgorithm = hashAlgorithm;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public (string hash, string salt) HashString(string stringToHash)
        {
            
            var byteValue = Encoding.UTF8.GetBytes(stringToHash);

            byte[] salt = new byte[128];
            _randomNumberGenerator.GetBytes(salt);
             
            var saltedValue = byteValue.Concat(salt).ToArray();

            var hash = _hashAlgorithm.ComputeHash(saltedValue);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt)); 
        }

        public (string hash, string salt) HashString(string stringToHash, string salt)
        {
            var byteValue = Encoding.UTF8.GetBytes(stringToHash);

            var byteSalt = Convert.FromBase64String(salt);

            var saltedValue = byteValue.Concat(byteSalt).ToArray();

            var hash = _hashAlgorithm.ComputeHash(saltedValue);

            return (Convert.ToBase64String(hash), salt);
        }
    }
}
