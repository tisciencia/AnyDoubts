using System.Web.Mvc;
using Ninject;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository;
using System;
using System.Net;

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
            var questions = Questions.FromUser(username);
            if (questions.Count == 0) ViewBag.Message = "The user has not answered any questions";
            return View(questions);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string username, string question)
        {
            User userProfile = Users.Load(user => user.Username == username);
            if (userProfile == null)
                return HttpNotFound();                

            if (String.IsNullOrEmpty(question))
            {
                ViewBag.UserName = "Pergunta Inválida!";
            }
            else
            {                
                Questions.Add(new Question(userProfile, question));
                Questions.Commit();
            }           
            
            return View(Questions.GetAll());
        }        
    }
}
