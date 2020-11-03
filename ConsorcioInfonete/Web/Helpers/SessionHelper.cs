using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositories.Context;

namespace Web.Helpers
{
    public class SessionHelper
    {
        public static Usuario GetCurrentSession()
        {
            var user = (Usuario) HttpContext.Current.Session["User"];
            return user;
        }

        public static  void SetSession(Usuario usuario)
        {
            HttpContext.Current.Session["User"] = usuario;
        }


    }
}