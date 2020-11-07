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
        
        public ActionResult VerGastos(int idConsorcio)
        {
            List<Gasto> gastos = gastoService.ObtenerGastoPorConsorcio(idConsorcio);
            if (gastos.Count>0)
            {
                ViewBag.nombre = gastos[0].Consorcio.Nombre;
                ViewBag.id = gastos[0].Consorcio.IdConsorcio;
            }
            return View(gastos);
        }

        public ActionResult CrearGasto(int idConsorcio)
        {
            GastoVM gasto= new GastoVM();
            gasto.idConsorcio = idConsorcio;
            return View(gasto);
        }

        [HttpPost]
        public ActionResult CrearGasto(GastoVM gasto, string accion, HttpPostedFileBase file)
        {

            if (!ModelState.IsValid)
            {
                return View(gasto);
            }
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Gastos/"), fileName);
                    file.SaveAs(path);
                    gasto.ArchivoComprobante = fileName;
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
                    return Redirect("/Gastos/VerGastos?idConsorcio=" + gasto.idConsorcio);
                }
         
              
            return Redirect("/Gastos/VerGastos?idConsorcio=" + gasto.idConsorcio);
        }

        public ActionResult Eliminar(int idGasto)
        {
            Gasto gasto = gastoService.ObtenerPorId(idGasto);
            return View(gasto);
        }

        public ActionResult EliminarGasto(int idGasto)
        {
            Gasto gasto = gastoService.ObtenerPorId(idGasto);
            int idConsorcio = gasto.IdConsorcio;
            gastoService.Eliminar(gasto.IdGasto);
            return Redirect("/Gastos/VerGastos?idConsorcio=" + idConsorcio);
        }

        public ActionResult Modificar(int idGasto)
        {
            Gasto gasto = gastoService.ObtenerPorId(idGasto);
                     
            GastoVM gastoVM = new GastoVM();
            gastoVM = gastoVM.MapearInversa(gasto);
            return View(gastoVM);
        }       
     
        [HttpPost]
        public ActionResult Modificar(GastoVM gasto, HttpPostedFileBase file)
        {
            //gasto.idUsuario = SessionHelper.GetCurrentSession().IdUsuario;
            if (!ModelState.IsValid)
            {
                return View(gasto);
            }
            if (file != null || gasto.ArchivoComprobante=="")
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Gastos/"), fileName);
                file.SaveAs(path);
                gasto.ArchivoComprobante = fileName;
            }
            else
            {
                gasto.ArchivoComprobante = "";
            }
            Gasto g = gasto.Mapear(gasto);
            gastoService.Modificar(g);
            return Redirect("/Gastos/VerGastos?idConsorcio=" + g.IdConsorcio);

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
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + t);
            Response.TransmitFile(t);
            Response.End();
            return File(t, document);
            // return RedirectToAction("Lista");
        }
    }
}