using System.Collections.Generic;
using System.Web.Mvc;
using AnyDoubts.DAO;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository;
using AnyDoubts.Web.Controllers;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Utils;
using WatiN.Core;

namespace AnyDoubts.Specs
{
    [Binding]
    public class ListUsersQuestions
    {
        private Mock<IQuestions> _mock;
        private UserController _userController;

        private IE CurrentBrowser
        {
            get { return ScenarioContext.Current["browser"] as IE; }   
            set { ScenarioContext.Current["browser"] = value; }
        }

        public ListUsersQuestions()
        {
            _mock = new Mock<IQuestions>();
        }

        [Given(@"I am a visitor")]
        public void GivenIAmAVisitor()
        {
        }

        [Given(@"There is a user called ""(.*)""")]
        public void GivenThereIsAUserCalledVintem(string username)
        {
            new User(username);
        }

        [Given(@"the user ""(.*)"" has no answered questions")]
        public void GivenTheUserVintemHasNoAnsweredQuestions(string username)
        {
            _mock.Setup(q => q.FromUser(username)).Returns(new List<Question>());            
            _userController = new UserController();
            _userController.Questions = _mock.Object;
        }

        [When(@"I visit ""(.*)""'s profile  page")]
        public void WhenIVisitVintemSProfilePage(string username)
        {
            //CurrentBrowser = new IE(string.Format("http://localhost:4265/{0}", username));
            var actionResult = _userController.Index(username);
            ScenarioContext.Current.Set(actionResult);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSeeTheUserHasNotAnsweredAnyQuestions(string message)
        {
            var result = (ViewResult)ScenarioContext.Current.Get<ActionResult>();
            Assert.AreEqual(message, result.ViewBag.Message);
        }
    }
}
