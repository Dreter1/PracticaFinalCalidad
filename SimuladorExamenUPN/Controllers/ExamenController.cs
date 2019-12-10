using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SimuladorExamenUPN.Servicios;
using SimuladorExamenUPN.Interfaces;

namespace SimuladorExamenUPN.Controllers
{
    public class ExamenController : BaseController
    {
        private readonly ISessionService session;
        private readonly IExamenService servicioExamen;
        private readonly ITemasServices servicioTema;
        private readonly IPreguntasService servicioPreguntas;

        public ExamenController(ISessionService session, IExamenService servicioExamen, ITemasServices servicioTema, IPreguntasService servicioPreguntas)
        {
            this.session = session;
            this.servicioExamen = servicioExamen;
            this.servicioTema = servicioTema;
            this.servicioPreguntas = servicioPreguntas;
        }

        [HttpGet]
        public ActionResult Index()
        {
            int UsuarioId = session.ConvertirSessionIdAIntId();
            return View(servicioExamen.GetExamenByUserId(UsuarioId));
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Temas = servicioTema.GetTemaAsList();
            return View(new Examen());
        }

        [HttpPost]
        public ActionResult Crear(Examen examen, int nroPreguntas)
        {
            if (ModelState.IsValid)
            {
                servicioExamen.CrearExamen(examen);
                List<Pregunta> preguntas = servicioPreguntas.GenerarPreguntas(examen.TemaId, nroPreguntas);
                servicioPreguntas.GuardarPreguntas(examen, preguntas);

                return RedirectToAction("Index");
            }
            ViewBag.Temas = servicioTema.GetTemaAsList();
            return View(examen);
        }
    }
}
