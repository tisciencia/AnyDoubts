using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AnyDoubts.DAO;
using Db4objects.Db4o;
using SharpTestsEx;
using AnyDoubts.Domain.Repositoy;

namespace AnyDoubts.Tests.Repository
{
    [TestFixture]
    public class SessionManagerTests
    {
        [Test]
        public void SessionManagerShouldBeOpen()
        {
            SessionManagerFactory.GetInstance().IsClosed().Should().Be(false);
        }
    }
}
