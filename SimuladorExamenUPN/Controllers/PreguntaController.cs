using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class PreguntaController : BaseController
    {
        private readonly IPreguntasService servicioPregunta;
        private readonly ITemasServices servicioTema;

        public PreguntaController(IPreguntasService servicioPregunta, ITemasServices servicioTema)
        {
            this.servicioPregunta = servicioPregunta;
            this.servicioTema = servicioTema;
        }

        [HttpGet]
        public ActionResult Index(int temaId)
        {
            return View(servicioTema.GetTemaById(temaId));
        }

        [HttpGet]
        public ActionResult Crear(int temaId)
        {
            ViewBag.Tema = servicioTema.GetTemaById(temaId);
            return View(new Pregunta());
        }

        [HttpPost]
        public ActionResult Crear(Pregunta pregunta)
        {
            Validar(pregunta);
            if (!ModelState.IsValid)
            {
                ViewBag.Tema = servicioTema.GetTemaById(pregunta.TemaId);
                return View(pregunta);
            }

            servicioPregunta.CrearPregunta(pregunta);

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {            
            var pregunta = servicioPregunta.GetPreguntaById(id);
            ViewBag.Tema = servicioTema.GetTemaById(pregunta.TemaId);
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult Editar(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tema = servicioTema.GetTemaById(pregunta.TemaId);
                return View(pregunta);
            }

            servicioPregunta.EditarPregunta(pregunta);

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            servicioPregunta.EliminarPregunta(id);
            return RedirectToAction("Index");
        }

        private void Validar(Pregunta pregunta)
        {
            if (pregunta.Alternativas.Count < 4)
                ModelState.AddModelError("Alternativas", "Las alternativas deben ser al menos 4");

            if (pregunta.Alternativas.Where(o => o.EsCorrecto).Count() == 0)
                ModelState.AddModelError("Alternativas", "Las alternativas deben tener al mensos una respusta correcta");
        }

    }
}