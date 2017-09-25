using Castle.Facilities.Logging;
using Castle.Services.Logging.SerilogIntegration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Mvc;

namespace InterceptorExample.IoC
{
    public static class Register
    {
        private static IWindsorContainer _container;
        private static IDependencyResolver _resolver;

        public static void Run()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());

            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);



            _container.AddFacility<LoggingFacility>(f => f.LogUsing<SerilogFactory>());
        }

        public static void Dispose()
        {
            _container.Dispose();
        }
    }

    //public class LoggingFacility : IFacility
    //{
    //    public void LogUsing<T>()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void Init(IKernel kernel, IConfiguration facilityConfig)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void Terminate()
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}
}
