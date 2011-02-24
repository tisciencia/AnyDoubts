using System.Web.Mvc;
using AnyDoubts.Web.Filters;
using Ninject;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository;
using AnyDoubts.Web.ViewModels;
using Resources;

namespace AnyDoubts.Web.Controllers
{
    public class UserController : Controller
    {
        [Inject]
        public IQuestions Questions { get; set; }

        [Inject]
        public IUsers Users { get; set; }

        [UserRequired]
        public ViewResult Index(string username)
        {
            ViewBag.UserName = username;
            return ListUsersQuestions(username);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [UserRequired]
        public ViewResult Index(string username, UserProfile profile)
        {
            var userProfile = Users.Load(user => user.Username == username);

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

            ViewBag.Message = Messages.QuestionPostedWithSuccess;
            return ListUsersQuestions(username);
        }

        private ViewResult ListUsersQuestions(string username)
        {
            var questions = Questions.AllAnsweredByUser(username);
            if (questions.Count == 0) ViewBag.Message = Messages.NoQuestionsAnswered;
            return View("Index", new UserProfile { Questions = questions });
        }
    }
}
