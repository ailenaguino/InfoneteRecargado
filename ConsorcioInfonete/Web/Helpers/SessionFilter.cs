using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Helpers
{
    public class SessionFilter:ActionFilterAttribute
    {
        public static string LastUrl { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.RawUrl != "/Home/LogOut" && filterContext.ActionDescriptor.ActionName != "Error")
            {
                if (SessionHelper.GetCurrentSession() == null)
                {
                    if (filterContext.Controller is HomeController == false)
                    {
                        LastUrl = "~" + filterContext.HttpContext.Request.RawUrl;
                        filterContext.HttpContext.Response.Redirect("~/Home/Login");
                    }
                }
                else
                {
                    LastUrl = null;
                    if (filterContext.Controller is HomeController)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Consorcio/Lista");
                    }

                }
            }
           
            base.OnActionExecuting(filterContext);
        }
      
    }
}