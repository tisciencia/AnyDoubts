using System.Web.Mvc;
using System.Web.Routing;
using AnyDoubts.DAO;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository;
using Ninject;

namespace AnyDoubts.Web.Filters
{
    public class UserRequiredAttribute : ActionFilterAttribute
    {
        private string _userName;

        private IUsers _users;

        [Inject]
        public IUsers Users
        {
            get { return _users ?? (_users = new UserDAO()); }
            set { _users = value; }
        }

        public string UserName
        {
            get
            {
                if (string.IsNullOrEmpty(_userName)) _userName = "username";
                return _userName;
            }
            set { _userName = value; }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var username = filterContext.ActionParameters[UserName] as string;
            var user = new User(username);
            if (!Users.IsStored(user) && username != "favicon.ico")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                     {
                                                                         {"controller", "Error"},
                                                                         {"action", "Unknown"}
                                                                     });
            }
        }
    }
}