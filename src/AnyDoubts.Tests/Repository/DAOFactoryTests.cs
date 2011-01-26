using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpTestsEx;
using NUnit.Framework;
using AnyDoubts.DAO;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Tests.Repository
{
    [TestFixture]
    public class DAOFactoryTests
    {
        [Test]
        public void DAOFactoryShouldCreateANewInstanceOfIQuestion()
        {
            IList<Question> questions =  DAOFactory.Get<IQuestions>().GetAll();
            DAOFactory.Get<IQuestions>().Should().Not.Be(null);
        }      
    }
}
