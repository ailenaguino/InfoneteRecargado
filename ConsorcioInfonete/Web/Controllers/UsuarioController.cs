using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories.Context;
using Services;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioService servicio;
        public UsuarioController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            servicio = new UsuarioService(contexto);
        }

        public ActionResult Login()
        {
            return View(new UsuarioVM());
        }
       
        [HttpPost]
        public ActionResult Validate(UsuarioVM user)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = servicio.GetByEmailAndPassword(user.Email, user.Password);
                if (usuario != null)
                {
                    SessionHelper.SetSession(usuario);
                    if (SessionFilter.LastUrl != null) return Redirect(SessionFilter.LastUrl);
                    return RedirectToAction("Index", "Consorcio");

                }

                ViewBag.Error = "Email o contraseña incorrectos.";
                return View("Login");
            }
            return View("Login");
        }
    }
}