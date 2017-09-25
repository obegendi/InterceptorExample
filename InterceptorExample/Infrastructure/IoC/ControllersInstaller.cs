using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using InterceptorExample.Cache;
using InterceptorExample.Controllers;
using InterceptorExample.Service;

namespace InterceptorExample.IoC
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ExceptionHandlingInterceptor>().LifestyleSingleton());
            container.Register(Component.For<CacheInterceptor>().LifestyleSingleton());

            container.Register(Component.For(typeof(ICache))
                .ImplementedBy(typeof(CacheProvider))
                .LifestyleSingleton());

            container.Register(Classes.FromThisAssembly()
				.Pick().If(t => t.Name.EndsWith("Controller"))
				.Configure(configurer => configurer.Named(configurer.Implementation.Name))
				.LifestylePerWebRequest());

            container.Register(Component.For(typeof(IHelloService))
                .ImplementedBy(typeof(HelloService))
                    .Interceptors(typeof(ExceptionHandlingInterceptor)).Interceptors(typeof(CacheInterceptor)).LifestylePerWebRequest());

           
        }
    }
}