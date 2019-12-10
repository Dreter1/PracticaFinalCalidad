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
    public class TemaController : BaseController
    {
        private readonly ITemasServices servicioTema;
        private readonly ICategoriaService servicioCategoria;
        private readonly ITemaCategoriaService servicioTemaCategoria;

        public TemaController(ITemasServices servicioTema, ICategoriaService servicioCategoria, ITemaCategoriaService servicioTemaCategoria)
        {
            this.servicioTema = servicioTema;
            this.servicioCategoria = servicioCategoria;
            this.servicioTemaCategoria = servicioTemaCategoria;
        }

        [HttpGet]
        public ViewResult Index(string criterio)
        {
            ViewBag.Criterio = criterio;
            return View(servicioTema.GetTemaAsListByCriterio(criterio));
        }

        [HttpGet]
        public ViewResult Crear()
        {
            ViewBag.Categorias = servicioCategoria.GetCategoriaAsList();
            ViewBag.Message = "Pantalla de crear";
            return View(new Tema());
        }

        [HttpPost]
        public ActionResult Crear(Tema tema,List<int> Ids)
        {
            ViewBag.Categorias = servicioCategoria.GetCategoriaAsList();

            if (tema == null || Ids == null)
            {
                return View(tema);
            }                        

            if (ModelState.IsValid)
            {
                servicioTema.Crear(tema);
                servicioTemaCategoria.Crear(tema, Ids);        
                return RedirectToAction("Index");
            }

            return View(tema);
        }

        [HttpGet]
        public ViewResult Editar(int id)
        {              
            Tema tema = servicioTema.GetTemaById(id);           
            return View(tema);
        }

        [HttpPost]
        public ActionResult Editar(Tema tema)
        {      
            if (ModelState.IsValid)
            {
                servicioTema.Editar(tema);
                return RedirectToAction("Index");
            }

            return View(tema);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            servicioTema.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}