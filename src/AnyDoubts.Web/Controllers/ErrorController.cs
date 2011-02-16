using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace AnyDoubts.Web.Controllers
{
    public class ErrorController : Controller
    {        
        public ViewResult Unknown()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View("Unknown");
        }
        
        public ViewResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View("NotFound");
        }
    }
}
