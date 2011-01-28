using System.Web.Mvc;
using AnyDoubts.DAO;
using AnyDoubts.Domain.Repositoy;
using Ninject;

namespace AnyDoubts.Web.Controllers
{
    public class UserController : Controller
    {
        [Inject]
        IQuestions Questions { get; set; }        

        public UserController()
        {
        }

        public UserController(IQuestions questionsRepository)
        {
            Questions = questionsRepository;
        }

        public ActionResult Index(string username)
        {
            ViewBag.UserName = username;
            var questions = Questions.FromUser(username);
            if (questions.Count == 0) ViewBag.Message = "The user has not answered any questions";
            return View(questions);
        }

    }
}
