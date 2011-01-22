using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.DAO;
using SharpTestsEx;

namespace AnyDoubts.Tests.Repository
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        [Test]
        public void DAOFactoryTest()
        {
            IQuestions questions = DAOFactory.Get<IQuestions>();

            questions.Should().Not.Be(null);
        }
    }
}
