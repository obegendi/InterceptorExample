using System;
using Helpers;
using InterceptorExample.IoC;

namespace InterceptorExample.Service
{
    public interface IHelloService
    {
        MethodResult Foo();
        [Cache()]
        DateTime Too();
    }
}