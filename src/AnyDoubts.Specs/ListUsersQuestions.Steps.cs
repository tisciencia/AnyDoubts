using System.Collections.Generic;
using System.Web.Mvc;
using AnyDoubts.DAO.DAOs;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.Web.Controllers;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Table = TechTalk.SpecFlow.Table;

namespace AnyDoubts.Specs
{
    [Binding]
    public class ListUsersQuestions
    {
        private readonly Mock<IQuestions> _mock;
        private User _currentUser;
        private readonly UserController _userController;
        private ActionResult _result;
        private List<Question> _expectedQuestions;

        public ListUsersQuestions()
        {
            _mock = new Mock<IQuestions>();
            _userController = new UserController(_mock.Object);
        }

        [Given(@"I am a visitor")]
        public void GivenIamAVisitor()
        {
        }

        [Given(@"There is a user called ""(.*)""")]
        public void GivenThereIsAUserCalledVintem(string username)
        {
            _currentUser = new User(username);
            var userRepository = new UserRepository();
            userRepository.Add(_currentUser);
            userRepository.Commit();
        }

        [Given(@"the user ""(.*)"" has no answered questions")]
        public void GivenTheUserVintemHasNoAnsweredQuestions(string username)
        {
            _mock.Setup(q => q.FromUser(username)).Returns(new List<Question>());
        }

        [When(@"I visit ""(.*)""'s profile page")]
        public void WhenIVisitVintemSProfilePage(string username)
        {
            _result = _userController.Index(username);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSeeTheUserHasNotAnsweredAnyQuestions(string message)
        {
            var viewResult = _result as ViewResult;
            Assert.AreEqual(message, viewResult.ViewBag.Message);
        }

        [Given(@"the user ""vintem"" has the following questions")]
        public void GivenTheUserVintemHasTheFollowingQuestions(Table table)
        {
            _expectedQuestions = new List<Question>();
            foreach (var row in table.Rows)
            {
                var question = new Question(row["Question"]) { Answer = row["Answer"], To = _currentUser };
                _expectedQuestions.Add(question);
            }
            _mock.Setup(x => x.FromUser(It.IsAny<string>())).Returns(_expectedQuestions);
        }

        [Then(@"I should see")]
        public void ThenIShouldSee(Table table)
        {
            var viewResult = _result as ViewResult;
            Assert.IsInstanceOf(typeof(IEnumerable<Question>), viewResult.Model);
            Assert.AreEqual(_expectedQuestions, viewResult.Model);
        }
    }
}
