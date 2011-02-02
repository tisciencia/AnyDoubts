using System.Collections.Generic;
using AnyDoubts.DAO.DAOs;
using AnyDoubts.Domain.Model;
using NUnit.Framework;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.DAO;
using SharpTestsEx;

namespace AnyDoubts.Tests.Repository
{
    [TestFixture]
    public class QuestionRepositoryTests
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
            var questions = _questionsRepository.FromUser("vintem");
            Assert.NotNull(questions);
            Assert.IsInstanceOf(typeof(IList<Question>), questions);
        }

        [Test]
        public void QuestionsRepository_FromUser_should_return_questions_answered_from_a_specific_user()
        {
            User user2;
            User user1 = GetUsers(out user2);

            _questionsRepository.Add(new Question("Question1")
                                         {
                                             To = user1,
                                             Answer = "Test"
                                         });
            _questionsRepository.Add(new Question("Question2")
            {
                To = user2,
                Answer = "Test"
            });
            _questionsRepository.Add(new Question("Question3")
            {
                To = user1
            });

            var questions = _questionsRepository.FromUser("vintem");
            Assert.AreEqual(1, questions.Count);
            Assert.AreEqual("Question1", questions[0].Message);
        }

        private static User GetUsers(out User user2)
        {
            var userRepository = new UserRepository();
            var user1 = new User {Username = "vintem"};
            user2 = new User {Username = "anyuser"};
            userRepository.Add(user1);
            userRepository.Add(user2);
            userRepository.Commit();
            return user1;
        }
    }
}
