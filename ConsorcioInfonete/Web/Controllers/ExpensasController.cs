using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ExpensasController : Controller
    {
        // GET: Expensas
        public ActionResult Index()
        {
            return View();
        }
    }
}