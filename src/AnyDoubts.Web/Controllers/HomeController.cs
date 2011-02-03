using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository;
using AnyDoubts.DAO;
using Ninject;

namespace AnyDoubts.Web.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IQuestions Questions { get; set; }

        public HomeController()
        {
        }

        public ActionResult Index()
        {            
            ViewBag.Message = "Ask me anything";
            return View(Questions.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string question)
        {
            ViewBag.Message = "Ask me anything";            
            Questions.Add(new Question(new User(), question));
            Questions.Commit();
            return View(Questions.GetAll());            
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
