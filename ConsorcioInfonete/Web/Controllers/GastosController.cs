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
        private FileVM fileModel;
        public GastosController()
        {
            PW3_TP_20202CEntities ctx = new PW3_TP_20202CEntities();
            gastoService = new GastoService(ctx);
            fileModel = new FileVM();
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
            public ActionResult CrearGasto(GastoVM gasto, string accion)
        {
            //si no ingreso archivo
            if (gasto.fileComrobante == null && gasto.ArchivoComprobante==null)
            {
                
                ViewBag.msj = "Ingrese el archivo comprobante";
                return View(gasto);
            }
            //no cargo el archivo pero ya tenia uno
            /* else if (gasto.fileComrobante == null && gasto.ArchivoComprobante != null)//tengo un archivo y el file es null -> no lo toco
             {
                 HttpPostedFileBase FileBase = new FileVM(gasto.ArchivoComprobante);
                 gasto.fileComrobante = FileBase;
             }
             else if (gasto.fileComrobante != null && gasto.ArchivoComprobante == null) //cargo un archivo y no habia cargado antes
             {
                 gasto.ArchivoComprobante = gasto.fileComrobante.FileName;
                 fileModel.GuardarArchivo(gasto.fileComrobante, Server);
             }
             else if (gasto.fileComrobante != null && gasto.ArchivoComprobante != null) //cargo un archivo y tenia uno antes
             {
                 gasto.ArchivoComprobante = gasto.fileComrobante.FileName;
                 fileModel.GuardarArchivo(gasto.fileComrobante, Server);
             }*/
             fileModel.AltaDeArchivoComprobante(gasto,Server);
            if (!ModelState.IsValid)
            {
                return View(gasto);
            }

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
                fileModel.GuardarArchivo(gasto.fileComrobante, Server);
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