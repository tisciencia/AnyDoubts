using System.Web.Mvc;
using Ninject;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository;
using System;
using System.Net;
using AnyDoubts.Web.ViewModels;

namespace AnyDoubts.Web.Controllers
{
    public class UserController : Controller
    {
        [Inject]
        public IQuestions Questions { get; set; }

        [Inject]
        public IUsers Users { get; set; }

        public UserController()
        {
        }

        public ActionResult Index(string username)
        {
            ViewBag.UserName = username;
            var questions = Questions.AllAnsweredByUser(username);
            if (questions.Count == 0) ViewBag.Message = "O usuário ainda não respondeu nenhuma pergunta.";
            return View(new UserProfile() { Questions = questions });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string username, UserProfile profile)
        {
            User userProfile = Users.Load(user => user.Username == username);
            if (userProfile == null)
                return View("Error");

            if (ModelState.IsValid)
            {                
                Question newQuestion;
                if (Request.IsAuthenticated)
                {
                    User userFrom = Users.Load(user => user.Username == User.Identity.Name);
                    newQuestion = new Question(userFrom, userProfile, profile.NewQuestion);
                }
                else
                    newQuestion = new Question(userProfile, profile.NewQuestion);

                Questions.Add(newQuestion);
                Questions.Commit();
            }

            ViewBag.Message = "Pergunta enviada com sucesso!";
            return View(new UserProfile() { Questions = Questions.AllAnsweredByUser(username) });
        }
    }
}
