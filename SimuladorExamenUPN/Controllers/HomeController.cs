using SimuladorExamenUPN.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SimuladorExamenUPN.Interfaces;

namespace SimuladorExamenUPN.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IExamenService servicio;

        public HomeController(IExamenService servicio)
        {
            this.servicio = servicio;
        }

        public ActionResult Index()
        {
            return View(servicio.GetExamenAsList());
        }

        public ActionResult Confirmar(int ExamenId)
        {
            return View(servicio.GetExamenById(ExamenId));
        }

        public ActionResult DarExamen(int ExamenId)
        {
            return View(servicio.RealizarExamenById(ExamenId));
        }
        
    }
}