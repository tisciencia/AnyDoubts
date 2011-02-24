using System.Web;
using System.Web.Routing;
using AnyDoubts.Web;
using Moq;
using NUnit.Framework;

namespace AnyDoubts.Tests.Web
{
    [TestFixture]
    public class RoutesTests
    {
        private Mock<HttpContextBase> _httpContext;
        private RouteCollection _routes;

        [SetUp]
        public void Setup()
        {
            _routes = new RouteCollection();
            MvcApplication.RegisterRoutes(_routes);
            _httpContext = new Mock<HttpContextBase>();
        }

        [Test]
        public void Root_path_should_go_to_home_controller()
        {
            _httpContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/");

            var routeData = _routes.GetRouteData(_httpContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);
        }

        [Test]
        public void Visit_a_user_profile_should_go_to_user_controller()
        {
            _httpContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/username");

            var routeData = _routes.GetRouteData(_httpContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("User", routeData.Values["controller"]);
        }
    }
}
