using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AnyDoubts.Web.Controllers;
using System.Web.Mvc;

namespace AnyDoubts.Specs
{
    [Binding]
    public class Account
    {
        //private readonly Mock<IAccount> _mock;
        //private User _currentUser;
        private AccountController _accountController;
        private ActionResult _result;
        //private List<Question> _expectedQuestions;

        public Account()
        {
            //_mock = new Mock<IQuestions>();
            _accountController = new AccountController();
        }

        [Given(@"an anonymous user")]
        public void GivenAnAnonymousUser()
        {            
        }

        [When(@"she goes to / SignUp")]
        public void WhenSheGoesToSignup()
        {
            
        }

        [Then(@"she should be at the 'users/new' page")]
        public void ThenSheShouldBeAtTheUsersNewPage()
        {
            _result = _accountController.SignUp();
        }

        [Then(@"she should see a <form> containing a textfield: Username, textfield: Email, password: Password, password: 'Confirm Password', submit: 'Sign up'")]
        public void ThenSheShouldSeeAFormContainingATextfieldUsernameTextfieldEmailPasswordPasswordPasswordConfirmPasswordSubmitSignUp()
        {
            
        }
    }
}
