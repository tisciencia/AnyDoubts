using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyDoubts.Domain.Model;
using AnyDoubts.Web.Services;
using System.Web.Routing;
using AnyDoubts.Domain.Repository;
using Ninject;
using System.Web.Security;
using AnyDoubts.Web.ViewModels;
using AutoMapper;
using Resources;

namespace AnyDoubts.Web.Controllers
{
    public class AccountController : Controller
    {
        [Inject]
        public IUsers Users { get; set; }
        [Inject]
        public IQuestions Questions { get; set; }
        public IFormsAuthenticationService FormsService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }

            base.Initialize(requestContext);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUp model)
        {            
            if (ModelState.IsValid)
            {
                User user = Users.Load(u => u.Username == model.Username);
                if (!Users.IsStored(user))
                {
                    //User newUser = new Domain.Model.User(model.Username, model.Email, model.Password);
                    var newUser = Mapper.Map<UserSignUp, User>(model);
                    Users.Add(newUser);
                    Users.Commit();
                    FormsService.SignIn(newUser.Username, false);
                    return RedirectToAction("InBox", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "This user is already registered, Please choose another username.");
                }
            }

            return View(model);
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserSignIn model)
        {
            if (ModelState.IsValid)
            {
                User user = Users.Load(u => u.Username == model.Username);
                if (Users.IsStored(user) && model.Password.Equals(user.Password))
                {
                    FormsService.SignIn(user.Username, false);
                    return RedirectToAction("InBox", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Inválid username or password.");
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult InBox()
        {
            ViewBag.UserName = User.Identity.Name;
            return ListUsersQuestions(User.Identity.Name);            
        }

        public ActionResult RetrieveUsername()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RetrieveUsername(string email)
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string username)
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }
        
        [Authorize]
        public ActionResult Delete(string idQuestion)
        {
            Question question = Questions.LoadByID(idQuestion);
            if (Questions.IsStored(question))
            {
                Questions.Delete(question);
                Questions.Commit();
                TempData["mensagem"] = Messages.QuestionDeletedWithSuccess;
            }            
            return RedirectToAction("InBox");
        }

        private ViewResult ListUsersQuestions(string username)
        {
            var questions = Questions.Unanswered(username);
            if (questions.Count == 0) ViewBag.DataMessage = Messages.NoQuestionsWereAskedForYouYet;
            return View("InBox", new Inbox { Questions = questions });
        }
    }
}
