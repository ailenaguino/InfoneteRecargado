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
        private ConsorcioService consorcioService;
        private UsuarioService usuarioService;

        public ConsorcioController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            consorcioService = new ConsorcioService(contexto);
            usuarioService = new UsuarioService(contexto);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            int idusuario = SessionHelper.GetCurrentSession().IdUsuario;
            Usuario consorcios = usuarioService.ObtenerPorId(idusuario);
            return View(consorcios);
        }

        

        
        public ActionResult Editar()
        {
            return View();
        }
       
    }
}