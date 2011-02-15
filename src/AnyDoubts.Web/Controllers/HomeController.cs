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
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
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
