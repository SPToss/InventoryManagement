using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Xunit;

namespace UserService.Test
{
    public class HashServiceTest
    {
        private readonly HashService _hashService;

        public HashServiceTest()
        {
            _hashService = new HashService(new SHA384Managed(), new RNGCryptoServiceProvider());
        }

        [Fact]
        public void HashStringMethodShouldCreateSaltIfNotPassedAndHash()
        {

            //Arrange
            var testString = TestObjects.GetTestStringToHash();

            //Act
            var result = _hashService.HashString(testString);

            //Assert
            Assert.NotNull(result.hash);
            Assert.NotNull(result.salt);

        }

        [Fact]
        public void HashStringMethodShouldReturnNewSaltEachTime()
        {
            //Arrange
            var testString = TestObjects.GetTestStringToHash();
            List<(string, string)> result = new List<(string, string)>();

            //Act
            result.Add(_hashService.HashString(testString));
            result.Add(_hashService.HashString(testString));
            result.Add(_hashService.HashString(testString));
            result.Add(_hashService.HashString(testString));
            result.Add(_hashService.HashString(testString));

            var distinctSalts = result.Select(x => x.Item2).Distinct();

            //Assert
            Assert.Equal(distinctSalts.Count(), result.Count());
        }

        [Fact]
        public void HashStringMethodShouldReturnSameHashForSameStringAndSalt()
        {
            //Arrange
            var testString = TestObjects.GetTestStringToHash();
            var testHashAndSalt = TestObjects.GetTestHashAndSalt();

            //Act
            var result = _hashService.HashString(testString, testHashAndSalt.salt);

            //Assert
            Assert.Equal(result.salt, testHashAndSalt.salt);
            Assert.Equal(result.hash, testHashAndSalt.hash);
        }
    }
}
