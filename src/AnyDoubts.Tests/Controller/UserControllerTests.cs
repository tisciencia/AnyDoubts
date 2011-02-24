using System.Collections.ObjectModel;
using System.Web.Mvc;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository;
using AnyDoubts.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace AnyDoubts.Tests.Controller
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _controller;
        private Mock<IQuestions> _questionRepository;

        [SetUp]
        public void Setup()
        {
            _controller = new UserController();
            _questionRepository = new Mock<IQuestions>();
            _controller.Questions = _questionRepository.Object;
        }

        [Test]
        public void Index_with_no_answered_questions_should_return_message()
        {
            const string username = "someuser";
            _questionRepository.Setup(q => q.AllAnsweredByUser(username)).Returns(new Collection<Question>());
            
            var result = _controller.Index(username) as ViewResult;

            Assert.IsNotNullOrEmpty(result.ViewBag.Message);
        }
    }
}
