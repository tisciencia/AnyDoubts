using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AnyDoubts.DAO;
using Db4objects.Db4o;
using SharpTestsEx;
using AnyDoubts.Domain.Repository;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Tests.Repository
{
    [TestFixture]
    public class FactoriesTests
    {
        [Test]
        public void ContainerFactoryShouldReturnANewInstanceOfContainerFactory()
        {
            ContainerFactory.GetInstance().Should().Not.Be(null);
        }

        [Test]
        public void SessionManagerFactoryShouldReturnANewInstanceOfSessionManager()
        {
            SessionManagerFactory.GetInstance().Should().Not.Be(null);
        }

        [Test]
        public void DAOFactoryShouldCreateANewInstanceOfIQuestion()
        {
            IList<Question> questions = DAOFactory.Get<IQuestions>().GetAll();
            DAOFactory.Get<IQuestions>().Should().Not.Be(null);
        }

        [Test]
        public void SessionManagerShouldBeOpen()
        {
            SessionManagerFactory.GetInstance().IsClosed().Should().Be(false);
        }
    }
}
