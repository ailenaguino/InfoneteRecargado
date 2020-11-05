using Repositories.Context;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class GastosController : Controller
    {
        private GastoService gastoService;

        public GastosController()
        {
            PW3_TP_20202CEntities ctx = new PW3_TP_20202CEntities();
            gastoService = new GastoService(ctx);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            List<Gasto> gastos = gastoService.ObtenerTodos();
            return View(gastos);
        }
        public ActionResult Alta()
        {
            return View(new GastoVM());
        }
        [HttpPost]
        public ActionResult Alta(GastoVM gasto, string accion)
        {
            if (accion == "Cancelar")
            {
                return RedirectToAction("Lista");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
           
            int idUser = SessionHelper.GetCurrentSession().IdUsuario;
            Gasto gast=gasto.Mapear(idUser, gasto);
            gastoService.Alta(gast);

            if (accion == "Guardar")
            {
                return RedirectToAction("Lista");                    
            }
          
            ViewBag.msj = "Creado con exito";
            return View();
        }
        public ActionResult Eliminar(int id)
        {
            Gasto g = gastoService.ObtenerPorId(id);
            return View(g);
        }
        [HttpPost]
        public ActionResult EliminarGasto(Gasto gasto)
        {
            gastoService.Eliminar(gasto.IdGasto);
            return RedirectToAction("Lista");
        }

        public ActionResult Modificar(int id)
        {
            Gasto gasto = gastoService.ObtenerPorId(id);
            if (gasto==null)
            {
                return RedirectToAction("Lista");
            }
            GastoVM g = new GastoVM();
            g=g.MapearInversa(gasto);
            return View(g);
        }
        [HttpPost]
        public ActionResult Modificar(GastoVM gasto)
        {
            gasto.idUsuario = SessionHelper.GetCurrentSession().IdUsuario;
            if (!ModelState.IsValid)
            {
                return View(gasto);
            }
            Gasto g = gasto.Mapear(gasto.idUsuario,gasto);
            gastoService.Modificar(g);
            return RedirectToAction("Lista");
        }
        public ActionResult Download(string t)
        {
            var document = t;
            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.bak
                FileName = t,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = false,
            };
            Response.AppendHeader("Content-Disposition", "attachment; filename="+t);
            Response.TransmitFile(t);
            Response.End();
            // return File(t, document);
            return RedirectToAction("Lista");
        }
        
      
    }
}