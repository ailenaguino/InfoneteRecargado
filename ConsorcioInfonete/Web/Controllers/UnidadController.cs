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
        ConsorcioService CS;

        public UnidadController()
        {
            PW3_TP_20202CEntities ctx = new PW3_TP_20202CEntities();
            US = new UnidadService(ctx);
            CS = new ConsorcioService(ctx);
        }

        // GET: Unidad
        public ActionResult VerUnidades(int id)
        {
            if (CS.ObtenerPorId(id).IdUsuarioCreador==SessionHelper.GetCurrentSession().IdUsuario)
            {
                List<Unidad> unidades = US.ObtenerTodos(id);

                return View(unidades);
            }

            return Redirect("/Consorcio/Lista");
        }

        public ActionResult CrearUnidad(int id)
        {
            if (CS.ObtenerPorId(id).IdUsuarioCreador == SessionHelper.GetCurrentSession().IdUsuario)
            {
                ViewData["Consorcio"] = CS.ObtenerPorId(id);
                return View(new Unidad());
            }

            return Redirect("/Consorcio/Lista");
        }

        [HttpPost]
        public ActionResult CrearUnidad(Unidad u, string guardar)
        {
            ViewData["Consorcio"] = CS.ObtenerPorId(u.IdConsorcio);

            if (ModelState.IsValid)
            {
                u.IdUsuarioCreador = SessionHelper.GetCurrentSession().IdUsuario;
                US.Alta(u);

                ViewData["alert"] = "Unidad " + u.Nombre + " creada con éxito";

                if (guardar == "Guardar") {
                    return RedirectToAction("VerUnidades/" + u.Consorcio.IdConsorcio);
                }
            }

            return View(new Unidad());
        }

        public ActionResult EditarUnidad(int id)
        {
            if (US.ObtenerPorId(id).IdUsuarioCreador == SessionHelper.GetCurrentSession().IdUsuario)
            {
                Unidad u = US.ObtenerPorId(id);

                return View(u);
            }

            return Redirect("/Consorcio/Lista");
        }

        [HttpPost]
        public ActionResult EditarUnidad(Unidad u)
        {
            Unidad unidadObtenida = US.ObtenerPorId(u.IdUnidad);
            u.Consorcio = unidadObtenida.Consorcio;

            if (ModelState.IsValid)
            {
                u.FechaCreacion = unidadObtenida.FechaCreacion;
                u.IdUsuarioCreador = unidadObtenida.IdUsuarioCreador;

                US.Modificar(u);
                return RedirectToAction("VerUnidades/" + u.Consorcio.IdConsorcio);
            }

            return View(u);
        }

        public ActionResult EliminarUnidad(int id)
        {
            if (US.ObtenerPorId(id).IdUsuarioCreador == SessionHelper.GetCurrentSession().IdUsuario)
            {
                Unidad u = US.ObtenerPorId(id);

                return View(u);
            }

            return Redirect("/Consorcio/Lista");
        }

        [HttpPost]
        public ActionResult EliminarUnidad(Unidad u)
        {
            Unidad unidadObtenida = US.ObtenerPorId(u.IdUnidad);
            US.Eliminar(u.IdUnidad);
            return RedirectToAction("VerUnidades/" + unidadObtenida.IdConsorcio);
        }

    }
}