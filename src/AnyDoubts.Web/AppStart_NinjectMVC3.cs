using System.Web.Mvc;
using Ninject;
using Ninject.Mvc3;
using AnyDoubts.Domain.Repository;
using AnyDoubts.DAO;

[assembly: WebActivator.PreApplicationStartMethod(typeof(AnyDoubts.Web.AppStart_NinjectMVC3), "Start")]

namespace AnyDoubts.Web {
    public static class AppStart_NinjectMVC3 {
        public static void RegisterServices(IKernel kernel) {
            kernel.Bind<IQuestions>().To<QuestionDAO>();
            kernel.Bind<IUsers>().To<UserDAO>();
        }

        public static void Start() {
            // Create Ninject DI Kernel 
            IKernel kernel = new StandardKernel();

            // Register services with our Ninject DI Container
            RegisterServices(kernel);

            // Tell ASP.NET MVC 3 to use our Ninject DI Container 
            DependencyResolver.SetResolver(new NinjectServiceLocator(kernel));
        }
    }
}
