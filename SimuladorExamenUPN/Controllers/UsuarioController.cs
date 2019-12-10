using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Manager;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimuladorExamenUPN.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ISessionService session;
        private readonly IAutManager autenticacion;
        private readonly IUsuarioService UsuarioService;

        public UsuarioController(ISessionService session, IAutManager autenticacion, IUsuarioService UsuarioService)
        {
            this.session = session;
            this.autenticacion = autenticacion;
            this.UsuarioService = UsuarioService;
        }

        [HttpGet]
        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                Usuario usuario = UsuarioService.GetUsuarioByCorreoAndClave(username, password);
                autenticacion.Login(usuario);
                session.GuardarSesion(usuario);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout() {
            autenticacion.Logout();
            session.LimpiarSesion();
            return RedirectToAction("Login");
        }
    }
}