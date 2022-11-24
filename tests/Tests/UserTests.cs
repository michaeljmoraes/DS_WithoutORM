using DocumentStorage.Core.DomainObjects;
using DocumentStorage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DocumentStorage.Tests
{
    public class UserTests
    {

        [Fact]
        public void Validate_UserNameNonAlphanumericException()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new User("user name", DateTime.Now, DateTime.Now)
            );
            Assert.Equal("UserName isn't a alphanumeric", ex.Message);
        }

        [Fact]
        public void Validate_UserNameEmptyException()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new User(string.Empty, DateTime.Now, DateTime.Now)
            );
            Assert.Equal("UserName could not be empty", ex.Message);
        }

        [Fact]
        public void Validate_UserNameMaxLengthException()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new User("test12345678912", DateTime.Now, DateTime.Now)
            );
            Assert.Equal("UserName exceeds maximum 14 characters", ex.Message);
        }
    }
}
