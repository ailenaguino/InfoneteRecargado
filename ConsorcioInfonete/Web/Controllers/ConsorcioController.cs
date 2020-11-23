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
        ProvinciaService provinciaService;
        UnidadService unidadService;


        public ConsorcioController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            consorcioService = new ConsorcioService(contexto);
            provinciaService = new ProvinciaService(contexto);
            unidadService = new UnidadService(contexto);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            int idusuario = SessionHelper.GetCurrentSession().IdUsuario;
      
                    List<Provincia> provincias = provinciaService.ObtenerTodos();
                    ViewBag.Provincias = provincias;
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
                ViewData["alerta"] = "Consorcio " + consorcio.Nombre + " creado con éxito";
                if (accion == "Guardar")
                {
                    return RedirectToAction("/Lista");
                }
                
                return View(consorcio);
            }

            return View();
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




        public ActionResult Editar(int idConsorcio)
        {
            int contar = 0;
            Consorcio consorcio = consorcioService.ObtenerPorId(idConsorcio);
            ViewBag.Con = consorcio;
            ConsorcioVM consorcioVM = new ConsorcioVM();
            List<Unidad> unidades = unidadService.ObtenerTodos(idConsorcio);
            foreach(Unidad u in unidades)
            {
                contar++;
            }
            ViewBag.uni = contar;
            return View(consorcioVM);
        }

        [HttpPost]
        public ActionResult EditarConsorcio(ConsorcioVM con)
        {

            if (!ModelState.IsValid)
            {
                return View(con);
            }


            Consorcio consorcio = con.Mapear(con);
            consorcioService.Modificar(consorcio);
            return Redirect("/Consorcio/Lista");

        }
    }
}