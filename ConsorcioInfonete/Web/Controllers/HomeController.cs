﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Repositories;
using Repositories.Context;
using Services;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private UsuarioService servicio;
        public HomeController()
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
                    servicio.UpdateLoginDate(usuario);
                    SessionHelper.SetSession(usuario);
                    if (SessionFilter.LastUrl != null) return Redirect(SessionFilter.LastUrl);
                    return RedirectToAction("Lista", "Consorcio");

                }

                ViewBag.Error = "Email o contraseña incorrectos.";
                return View("Login", new UsuarioVM());
            }
            return View("Login", new UsuarioVM());
        }

        public ActionResult Registro()
        {
            return View(new UsuarioRegistroVM());
        }
        [HttpPost]
        public ActionResult Register(UsuarioRegistroVM usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = new Usuario()
                    {
                        Email = usuario.Email,
                        Password = usuario.Password
                    };
                    servicio.Register(u);
                    return View("Login", new UsuarioVM());
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Registro", new UsuarioRegistroVM());
                }
            }
            return View("Registro", new UsuarioRegistroVM());
        }

        public ActionResult LogOut()
        {
            SessionHelper.RemoveSession();
            return View("Login",new UsuarioVM());
        }

        public ActionResult Error(int error = 0)
        {
            if(SessionHelper.GetCurrentSession() != null)
            {
                ViewBag.flag = true;
            }
            switch (error)
            {
                case 505:
                    ViewBag.Error = error;
                    ViewBag.Title = "Ocurrió un error inesperado";
                    ViewBag.Description = "Su petición no pudo completarse, por favor intente de nuevo";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Algo salio muy mal :( ..";
                    break;
            }

            return View();
        }

        public ActionResult Contacto()
        {
            if (SessionHelper.GetCurrentSession() != null)
            {
                ViewBag.flag = true;
            }
            return View();
        }
    }
}