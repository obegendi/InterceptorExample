using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;
using WebGrease;

namespace InterceptorExample.IoC
{
    public class ExceptionHandlingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine("entered");
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                //Logger.Instance.LogDebug($"Exception in : {invocation.Method.Name}");
                Debug.WriteLine($"Exception in : {invocation.Method.Name}");
                //invocation.ReturnValue = new BaseResponse { IsSuccess = false };
            }
        }
    }
}