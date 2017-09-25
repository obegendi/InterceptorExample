using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace InterceptorExample.IoC
{
    //public class DependencyScope : IDependencyScope
    //{
    //    private readonly IWindsorContainer _container;

    //    private readonly IDisposable _scope;

    //    public DependencyScope(IWindsorContainer container)
    //    {
    //        if (container == null)
    //        {
    //            throw new ArgumentNullException("container");
    //        }
    //        _container = container;
    //        _scope = container.BeginScope();
    //    }

    //    /// <summary>
    //    /// Resolves single registered services that support arbitrary object creation.
    //    /// </summary>
    //    /// <param name="serviceType">The type of the requested service or object.</param>
    //    /// <returns>
    //    /// The requested service or object.
    //    /// </returns>
    //    public object GetService(Type serviceType)
    //    {
    //        return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
    //    }

    //    /// <summary>
    //    /// Resolves multiple registered services.
    //    /// </summary>
    //    /// <param name="serviceType">The type of the requested services.</param>
    //    /// <returns>
    //    /// The requested services.
    //    /// </returns>
    //    public IEnumerable<object> GetServices(Type serviceType)
    //    {
    //        return _container.Kernel.HasComponent(serviceType) ?
    //            _container.Kernel.ResolveAll(serviceType).Cast<object>() : new object[] { };
    //    }


    //    public void Dispose()
    //    {
    //        _scope.Dispose();
    //    }
    //}
}