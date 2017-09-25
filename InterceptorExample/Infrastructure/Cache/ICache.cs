using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace InterceptorExample.Cache
{
    public interface ICache : IDisposable
    {
        object Get(string key);

        void Set(string key, object obj, DateTime expireDate);

        void Delete(string key);

        bool Exists(string key);
    }

    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
    }

    public class GetDistrictsByCityCodeResponse : BaseResponse
    {
        public List<string> CityList { get; set; }
    }

    public class CacheProvider : ICache
    {
        MemoryCache cache = new MemoryCache("MemCache");

        public CacheProvider()
        {
            
        }
        public void Dispose()
        {
            cache.Dispose();
        }

        public object Get(string key)
        {
            return cache.Get(key);
        }

        public void Set(string key, object obj, DateTime expireDate)
        {
            cache.Add(key, obj, expireDate);
        }

        public void Delete(string key)
        {
            cache.Remove(key);
        }

        public bool Exists(string key)
        {
            return cache.Contains(key);
        }
    }
}