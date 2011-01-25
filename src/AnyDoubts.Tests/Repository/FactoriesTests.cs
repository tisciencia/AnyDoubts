using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AnyDoubts.DAO;
using Db4objects.Db4o;
using SharpTestsEx;

namespace AnyDoubts.Tests.Repository
{
    [TestFixture]
    public class FactoriesTests
    {
        [Test]
        public void ContainerFactoryShouldReturnANewInstanceOfContainerFactory()
        {
            ContainerFactory.CreateSession().OpenClient().Should().Not.Be(null);
        }

        [Test]
        public void SessionManagerFactoryShouldReturnANewInstanceOfSessionManager()
        {
            SessionManagerFactory.GetInstance().Should().Not.Be(null);
        }
    }
}
