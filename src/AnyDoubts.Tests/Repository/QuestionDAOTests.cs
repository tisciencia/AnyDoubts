using System.Collections.Generic;
using AnyDoubts.Domain.Model;
using NUnit.Framework;
using AnyDoubts.Domain.Repository;
using AnyDoubts.DAO;
using SharpTestsEx;

namespace AnyDoubts.Tests.Repository
{
    [TestFixture]
    public class QuestionDAOTests
    {
        private IQuestions _questionsRepository;

        [SetUp]
        public void Setup()
        {
            _questionsRepository = DAOFactory.Get<IQuestions>();
        }

        [Test]
        public void DAOFactoryTest()
        {
            _questionsRepository.Should().Not.Be(null);
        }

        [Test]
        public void QuestionsRepository_FromUser_should_be_empty_if_theres_no_question_answered()
        {
            var questions = _questionsRepository.AllAnsweredByUser("vintem");
            Assert.NotNull(questions);
            Assert.IsInstanceOf(typeof(IList<Question>), questions);
        }

        [Test]
        public void QuestionsRepository_FromUser_should_return_questions_answered_from_a_specific_user()
        {
            User vintem = new User("vintem");
            User outro = new User("outro");
            _questionsRepository.Add(new Question(vintem, "Question1")
                                         {                                             
                                             Answer = "Test"
                                         });
            _questionsRepository.Add(new Question(outro, "Question2")
            {               
                Answer = "Test"
            });
            _questionsRepository.Add(new Question(vintem, "Question1"));

            var questions = _questionsRepository.AllAnsweredByUser("vintem");
            Assert.AreEqual(1, questions.Count);
        }      
    }
}
