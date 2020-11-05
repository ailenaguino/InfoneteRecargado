using Repositories.Context;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        public ActionResult Lista(int id)
        {
            List<Gasto> gastos = gastoService.ObtenerGastoPorConsorcio(id);
            if (gastos != null)
            {
                ViewBag.nombre = gastos.First().Consorcio.Nombre;
            }
            return View(gastos);
        }
        public ActionResult Alta()
        {
            return View(new GastoVM());
        }
        [HttpPost]
        public ActionResult AltaGasto(GastoVM gasto, string accion, HttpPostedFileBase file)
        {
            if (accion == "Cancelar")
            {
                return Redirect("/Gastos/Lista?id="+gasto.idConsorcio);
            }
            
                     
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Gastos"), fileName);
                file.SaveAs(path);
                gasto.ArchivoComprobante =fileName;
            }
            else
            {
                gasto.ArchivoComprobante = "";
            }
            int idUser = SessionHelper.GetCurrentSession().IdUsuario;
            gasto.idUsuario = idUser;
            Gasto gast = gasto.Mapear(gasto);
            gastoService.Alta(gast);

            if (accion == "Guardar")
            {
                return Redirect("/Gastos/Lista?id=" + gasto.idConsorcio);
            }

            ViewBag.msj = "Creado con exito";
            return View();
        }
        public ActionResult Eliminar(int id)
        {
            Gasto g = gastoService.ObtenerPorId(id);
            return View(g);
        }
        
        public ActionResult EliminarGasto(int idGasto)
        {
            Gasto gasto = gastoService.ObtenerPorId(idGasto);
            int idConsorcio = gasto.IdConsorcio;
            gastoService.Eliminar(gasto.IdGasto);
            return Redirect("/Gastos/Lista?id=" + idConsorcio);
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
         
        public ActionResult Download(string t)
        {
            var document = t;
            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.bak
                FileName = t,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = true,
            };
            Response.AppendHeader("Content-Disposition", "attachment; filename="+t);
            Response.TransmitFile(t);
            Response.End();
             return File(t, document);
           // return RedirectToAction("Lista");
        }

        [HttpPost]
        public ActionResult Modificar(GastoVM gasto)
        {
            gasto.idUsuario = SessionHelper.GetCurrentSession().IdUsuario;
            if (!ModelState.IsValid)
            {
                return View(gasto);
            }
            Gasto g = gasto.Mapear(gasto);
            gastoService.Modificar(g);
            return Redirect("/Gastos/Lista?id=" + g.IdConsorcio);

        }
    }
}