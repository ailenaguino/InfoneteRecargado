using Repositories.Context;
using Services;
using System;
using System.Collections.Generic;
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
        public ActionResult Alta(GastoVM gasto)
        {

            if (ModelState.IsValid)
            {
               int idusuario= SessionHelper.GetCurrentSession().IdUsuario;
                Gasto g = new Gasto()
                {
                    Nombre=gasto.Nombre,
                    Descripcion=gasto.Descripcion,
                    IdConsorcio = gasto.idConsorcio,
                    IdTipoGasto=gasto.idTipoGasto,
                    FechaGasto=gasto.Fecha,
                    AnioExpensa=gasto.AnioExpensa,
                    MesExpensa=gasto.MesExpensa,
                    ArchivoComprobante="",
                    Monto=gasto.Monto,
                    FechaCreacion=DateTime.Now,
                    IdUsuarioCreador= idusuario
                };
                gastoService.Alta(g);
            }
            return RedirectToAction("/Lista");

        }
        /*public ActionResult DownloadFile(string ld)
        {

            string filename = ld;
            string filepath = AppDomain.CurrentDomain.BaseDirectory+ "/Gastos/" +filename;

            return File(filepath, MediaTypeNames.Text.Plain, ld);
        }*/
    }
}