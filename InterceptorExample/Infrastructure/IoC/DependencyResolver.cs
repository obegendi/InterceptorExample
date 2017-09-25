﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;

namespace InterceptorExample.IoC
{
    internal class DependencyResolver : IDependencyResolver
    {
        IWindsorContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyResolver"/> class.
        /// </summary>
        /// <param name="container">The castle.</param>
        public DependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        /// <summary>
        /// Resolves single registered services that support arbitrary object creation.
        /// </summary>
        /// <param name="serviceType">The type of the requested service or object.</param>
        /// <returns>
        /// The requested service or object.
        /// </returns>
        public object GetService(Type serviceType)
        {
            if (_container.Kernel.HasComponent(serviceType))
            {
                return _container.Resolve(serviceType);
            }

            return null;
        }

        /// <summary>
        /// Resolves multiple registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>
        /// The requested services.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_container.Kernel.HasComponent(serviceType))
            {
                return _container.ResolveAll(serviceType).Cast<object>();
            }

            return new object[] { };
        }

        /// <summary>
        /// Releases the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public void Release(object instance)
        {
            _container.Release(instance);
        }
    }
}