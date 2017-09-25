using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers;
using InterceptorExample.IoC;
using ValidationModule;
using ValidationModule.Base;

namespace InterceptorExample.Service
{
    public class HelloService : IHelloService
    {
        public HelloService()
        {
        }

        
        public MethodResult Foo()
        {
            var context = new ValidateContext(new ValidateCompanyById(null));
            var previousVal = context.DoValidation(-1);

            //var companyEntity = _companyRepository.GetEntityById(Id);
            //var companyModel = companyEntity.ToModel();

            //context.Strategy = new ValidateCompanyModelExistance(previousVal);
            //context.DoValidation(companyModel);

            context.HandleResults();

            return new SuccessResult {Result = true};
        }

        [Cache()]
        public DateTime Too()
        {
            return DateTime.Now;
        }
    }
}