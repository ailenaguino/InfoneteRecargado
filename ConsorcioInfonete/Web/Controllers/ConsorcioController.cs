using Repositories.Context;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class ConsorcioController : Controller
    {
        ConsorcioService consorcioService;


        public ConsorcioController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            consorcioService = new ConsorcioService(contexto);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            int idusuario = SessionHelper.GetCurrentSession().IdUsuario;
            List<Consorcio> consorcios = consorcioService.ObtenerConsorciosDeUnUsuario(idusuario);
            return View(consorcios);
        }

        public ActionResult CrearConsorcio()
        {
            ConsorcioVM consorcio = new ConsorcioVM();

            return View(consorcio);
        }

        [HttpPost]
        public ActionResult CrearConsorcio(ConsorcioVM consorcio, string accion)
        {
            if (ModelState.IsValid)
            {
                consorcio.IdUsuarioCreador = SessionHelper.GetCurrentSession().IdUsuario;
                Consorcio con = consorcio.Mapear(consorcio);
                consorcioService.Alta(con);
                if (accion == "Guardar")
                {
                    return RedirectToAction("/Lista");
                }if(accion == "Guardar y Crear otro Consorcio")
                {
                    return RedirectToAction("/CrearConsorcio");
                }

            }
            

            return RedirectToAction("/Lista");
        }

        public ActionResult Eliminar(int idConsorcio)
        {
            Consorcio con = consorcioService.ObtenerPorId(idConsorcio);
            return View(con);
        }

        [HttpPost]
        public ActionResult EliminarConsorcio(int idConsorcio)
        {
            Consorcio con = consorcioService.ObtenerPorId(idConsorcio);
            consorcioService.Eliminar(con.IdConsorcio);
            return Redirect("/Consorcio/Lista");
        }




        public ActionResult Editar()
        {
            return View();
        }
       
    }
}