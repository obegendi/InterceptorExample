using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using InterceptorExample.Cache;
using Newtonsoft.Json;

namespace InterceptorExample.IoC
{
    public class CacheInterceptor : IInterceptor
    {
        private readonly ICache _cacheProvider;
        private readonly object _lockObject = new object();
        public CacheInterceptor(ICache cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            //method cache flag check
            var cacheAttribute = invocation.Method.GetAttribute<CacheAttribute>();
            if (cacheAttribute == null)//not flagged, continue
            {
                invocation.Proceed();
                return;
            }

            lock (_lockObject)
            {
                //create cache key
                var cacheKey = string.Concat(invocation.TargetType.FullName, ".", invocation.Method.Name, "(", JsonConvert.SerializeObject(invocation.Arguments), ")");
                //check cache with generated key
                var cachedObj = _cacheProvider.Get(cacheKey);
                if (cachedObj != null)//if contains return cached object
                {
                    invocation.ReturnValue = cachedObj;
                }
                else
                {
                    //if not proceed method and add value with generated key to cache 
                    invocation.Proceed();
                    var returnValue = invocation.ReturnValue;
                    
                        //If we check return values this is the place
                        if (returnValue != null)
                        {
                            var cacheExpireDate = DateTime.Now.AddSeconds(cacheAttribute.CacheDurationInSecond);
                            _cacheProvider.Set(cacheKey, invocation.ReturnValue, cacheExpireDate);
                        }
                    
                }
            }
        }
    }
}