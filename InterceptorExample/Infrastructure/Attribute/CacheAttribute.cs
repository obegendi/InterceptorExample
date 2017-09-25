using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;

namespace InterceptorExample.IoC
{
    [AttributeUsage(AttributeTargets.All)]
    public class CacheAttribute : Attribute
    {
        public int CacheDurationInSecond { get; private set; }

        public CacheAttribute(int cacheDurationInSecond = 300)
        {
            CacheDurationInSecond = cacheDurationInSecond;
        }
    }
}