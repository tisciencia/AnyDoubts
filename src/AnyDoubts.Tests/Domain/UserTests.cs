using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AnyDoubts.Domain.Model;
using SharpTestsEx;

namespace AnyDoubts.Tests.Domain
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void TwoUsersShouldBeEqual()
        {
            User user1 = new User("tisciencia");
            User user2 = new User("tisciencia");

            user1.Equals(user2).Should().Be(true);
        }

        [Test]
        public void TwoUsersShouldBeDiff()
        {
            User user1 = new User("tisciencia");
            User user2 = new User("vintem");

            user1.Equals(user2).Should().Be(false);
        }
    }
}
