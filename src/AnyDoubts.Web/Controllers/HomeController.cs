using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Message = "Ask me anything";

            List<Question> listaPerguntas = new List<Question>();
            Question q1 = new Question("Pergunta 1");
            q1.Answer = "Resposta 1";
            listaPerguntas.Add(q1);
            Question q2 = new Question("Pergunta 2");
            q2.Answer = "Resposta 2";
            listaPerguntas.Add(q2);

            return View(listaPerguntas);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string question)
        {
            Question newQuestion = new Question(question);

            //newQuestion.Message;

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
