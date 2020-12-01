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
        ConsorcioService consorcioService;
        private FileVM fileModel;
        public GastosController()
        {
            PW3_TP_20202CEntities ctx = new PW3_TP_20202CEntities();
            consorcioService = new ConsorcioService(ctx);
            gastoService = new GastoService(ctx);
            fileModel = new FileVM();
        }


        public ActionResult VerGastos(int idConsorcio)
        {
            Consorcio cs = consorcioService.ObtenerPorId(idConsorcio);
            if (cs == null || cs.IdUsuarioCreador != SessionHelper.GetCurrentSession().IdUsuario)
            {
                return Redirect("/Consorcio/Lista");
            }
            if (cs.IdUsuarioCreador!= SessionHelper.GetCurrentSession().IdUsuario)
            {
                return Redirect("/Consorcio/Lista");
            }
            List<Gasto> gastos = gastoService.ObtenerGastoPorConsorcio(idConsorcio);
            ViewBag.nombre = cs.Nombre;
            ViewBag.id = cs.IdConsorcio;
            
            return View(gastos);
        }

        public ActionResult CrearGasto(int idConsorcio)
        {
            List<Gasto> gastos = gastoService.ObtenerGastoPorConsorcio(idConsorcio);
            Consorcio cs = consorcioService.ObtenerPorId(idConsorcio);
            if (cs == null)
            {
                return Redirect("/Consorcio/Lista");
            }

            if (cs.IdUsuarioCreador != SessionHelper.GetCurrentSession().IdUsuario)
            {
                return Redirect("/Consorcio/Lista");
            }
            GastoVM gasto = new GastoVM();
            
            ViewBag.nombre =cs.Nombre;
            
            gasto.idConsorcio = idConsorcio;
            return View(gasto);
        }

        [HttpPost]
        public ActionResult CrearGasto(GastoVM gasto, string accion)
        {
            //si no ingreso archivo
            if (gasto.fileComrobante == null && gasto.ArchivoComprobante == null)
            {
                ViewBag.msj = "Ingrese el archivo comprobante";
                return View(gasto);
            }
         
            fileModel.AltaDeArchivoComprobante(gasto, Server);
            if (!ModelState.IsValid)return View(gasto);

            int idUser = SessionHelper.GetCurrentSession().IdUsuario;
            gasto.idUsuario = idUser;
            Gasto gast = gasto.Mapear(gasto);
            gastoService.Alta(gast);

            if (accion == "Guardar")
            {
                return Redirect("/Gastos/VerGastos?idConsorcio=" + gasto.idConsorcio);
            }
            ViewBag.gastoCreado = "Gasto " + gasto.Nombre + " creado con exito";
            return View(gasto);
        }


        public ActionResult Eliminar(int idGasto)
        {
            Gasto gasto = gastoService.ObtenerPorId(idGasto);
            if (gasto == null)
            {
                return Redirect("/Consorcio/Lista");
            }
          
            if (gasto.IdUsuarioCreador!= SessionHelper.GetCurrentSession().IdUsuario)
            {
                return Redirect("/Consorcio/Lista");
            }
            List<Gasto> gastos = gastoService.ObtenerGastoPorConsorcio(gasto.IdConsorcio);
            if (gastos.Count > 0)
            {
                ViewBag.nombre = gastos[0].Consorcio.Nombre;
                ViewBag.id = gastos[0].Consorcio.IdConsorcio;
            }
            return View(gasto);
        }
        [HttpPost]
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
            if (gastoService.ObtenerGastoPorConsorcio(gasto.IdConsorcio).FirstOrDefault().IdUsuarioCreador != SessionHelper.GetCurrentSession().IdUsuario)
            {
                return Redirect("/Consorcio/Lista");
            }
            GastoVM gastoVM = new GastoVM();
            List<Gasto> gastos = gastoService.ObtenerGastoPorConsorcio(gasto.IdConsorcio);
            if (gastos.Count > 0)
            {
                ViewBag.nombre = gastos[0].Consorcio.Nombre;
                ViewBag.id = gastos[0].Consorcio.IdConsorcio;
            }
            HttpPostedFileBase FileBase = new FileVM(gasto.ArchivoComprobante);
            gastoVM = gastoVM.MapearInversa(gasto);
            gastoVM.fileComrobante = FileBase;

            return View(gastoVM);
        }

        [HttpPost]
        public ActionResult Modificar(GastoVM gasto)
        {
            if (gasto.fileComrobante != null)//entra cuando edite
            {
                gasto.ArchivoComprobante = gasto.fileComrobante.FileName;
                fileModel.GuardarArchivo(gasto.fileComrobante, Server, gasto);
            }
            else //entra cuando no edite y voy a recuperarlo
            {
                HttpPostedFileBase FileBase = new FileVM(gasto.ArchivoComprobante);
                gasto.fileComrobante = FileBase;
            }

            if (!ModelState.IsValid)
            {
                return View(gasto);
            }

            Gasto g = gasto.Mapear(gasto);
            gastoService.Modificar(g);
            return Redirect("/Gastos/VerGastos?idConsorcio=" + g.IdConsorcio);

        }

        public ActionResult Download(string t)
        {
            if(t == "")
            {
                return Redirect("/Consorcio/Lista");
            }
            var document = t;
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = t,
                Inline = true,
            };
            /*Response.AppendHeader("Content-Disposition", "attachment; filename=" + t);
            Response.TransmitFile(t);
            Response.End();*/

            return File(t, document);


        }
    }
}