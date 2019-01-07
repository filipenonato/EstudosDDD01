using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Specs;

namespace MyStore.Domain.Tests.Account.Specs
{
    [TestClass]
    public class UserSpecTests
    {
        private List<User> _users;

        public UserSpecTests()
        {
            _users = new List<User>();

            _users.Add(new User("filipe.nonato@outlook.com", "filipenonato", "123456"));
            _users.Add(new User("homemdeferro@outlook.com", "ironman", "123456"));
            _users.Add(new User("batman@outlook.com", "batman", "123456"));
            _users.Add(new User("homemaranha@outlook.com", "spiderman", "123456"));
        }

        [TestMethod]       
        [TestCategory("User - Specs")]
        public void GetByUsernameShoudReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("filipenonato"))
                .FirstOrDefault();

            Assert.AreNotEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUsernameShoudNotReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("filipenonato234234243"))
                .FirstOrDefault();

            Assert.AreEqual(null, user);
        }
    }
}
