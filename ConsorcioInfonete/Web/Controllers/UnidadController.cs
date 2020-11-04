using Repositories.Context;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;

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

        public ActionResult CrearUnidad(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearUnidad(Unidad u)
        {
            if (ModelState.IsValid)
            {
                u.IdUsuarioCreador = SessionHelper.GetCurrentSession().IdUsuario;
                US.Alta(u);
            }
            return View();
        }

        public ActionResult EditarUnidad(int id)
        {
            Unidad u = US.ObtenerPorId(id);

            return View(u);
        }

        public ActionResult EditarUnidad(Unidad u)
        {
            if (ModelState.IsValid)
            {
                US.Modificar(u);
                return RedirectToAction("/Home/Index");
            }

            return View();
        }

    }
}