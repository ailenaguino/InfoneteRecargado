using System;
using System.Collections.Generic;
using System.Linq;
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
            if (SessionHelper.GetCurrentSession() == null)
            {
                if (filterContext.Controller is HomeController==false)
                {
                    LastUrl = "~"+filterContext.HttpContext.Request.RawUrl;
                    filterContext.HttpContext.Response.Redirect("~/Usuario/Login");
                }
            }
            else
            {
                if (filterContext.Controller is HomeController)
                {
                    filterContext.HttpContext.Response.Redirect("~/Consorcio/Index");
                }
                
            }
            base.OnActionExecuting(filterContext);
        }
      
    }
}