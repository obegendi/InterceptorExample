using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core;
using InterceptorExample.IoC;
using InterceptorExample.Service;

namespace InterceptorExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHelloService hello;

        [Interceptor(typeof(ExceptionHandlingInterceptor))]
        public HomeController(IHelloService hello)
        {
            this.hello = hello;
        }
        public ActionResult Index()
        {
            var q  = hello.Foo();
            var datetime = hello.Too();
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}