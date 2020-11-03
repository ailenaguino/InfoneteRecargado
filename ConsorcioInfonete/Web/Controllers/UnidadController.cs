using Repositories.Context;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UnidadController : Controller
    {
        UnidadService US;

        public UnidadController()
        {
            PW3_TP_20202CEntities ctx = new PW3_TP_20202CEntities();
            US = new UnidadService(ctx);
        }

        // GET: Unidad
        public ActionResult VerUnidades(int id)
        {
            List<Unidad> unidades = US.ObtenerTodos(id);

            return View(unidades);
        }
    }
}