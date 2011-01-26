using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.DAO;

namespace AnyDoubts.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Message = "Ask me anything";
            IQuestions questions = DAOFactory.Get<IQuestions>();
            return View(questions.GetAll());            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string question)
        {
            ViewBag.Message = "Ask me anything";
            IQuestions questions = DAOFactory.Get<IQuestions>();
            questions.Add(new Question(question));
            questions.Commit();
            return View(questions.GetAll());            
        }
        
        public ActionResult Kanban()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Colaboradores()
        {
            return View();
        }
    }
}
