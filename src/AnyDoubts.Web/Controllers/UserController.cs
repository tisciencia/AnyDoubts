using System.Web.Mvc;
using AnyDoubts.DAO;
using AnyDoubts.Domain.Repositoy;

namespace AnyDoubts.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IQuestions _questionsRepository;

        public UserController()
        {
            _questionsRepository = DAOFactory.Get<IQuestions>();
        }

        public UserController(IQuestions questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public ActionResult Index(string username)
        {
            ViewBag.UserName = username;
            var questions = _questionsRepository.FromUser(username);
            if (questions.Count == 0) ViewBag.Message = "The user has not answered any questions";
            return View(questions);
        }

    }
}
