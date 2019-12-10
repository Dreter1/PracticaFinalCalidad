using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public class ExamenService : IExamenService
    {
        private readonly SimuladorContext conexion;
        private readonly SessionService session;

        public ExamenService(SimuladorContext conexion)
        {
            this.conexion = conexion;
            session = new SessionService();
        }

        public List<Examen> GetExamenAsList()
        {
            return conexion.Examenes
                .Include(o => o.Tema.Categorias.Select(s => s.Categoria))
                .Include(o => o.Usuario)
                .Where(o => o.EstaActivo == true)
                .ToList();
        }

        public Examen GetExamenById(int? ExamenId)
        {
            if (ExamenId == null)
                return null;

            Examen examen = conexion.Examenes
                .Where(o => o.Id == ExamenId)
                .Include(o => o.Tema)
                .Include(u => u.Usuario)
                .FirstOrDefault();

            return examen;
        }

        public Examen RealizarExamenById(int? ExamenId)
        {
            if (ExamenId == null)
                return null;

            Examen examen = conexion.Examenes.Where(o => o.Id == ExamenId)
                .Include(o => o.Preguntas.Select(s => s.Pregunta.Alternativas))
                .FirstOrDefault();

            return examen;
        }

        public List<Examen> GetExamenByUserId(int? UsuarioId)
        {
            return conexion.Examenes
                .Where(o => o.UsuarioId == UsuarioId)
                .Include(o => o.Tema)
                .Include(o => o.Preguntas)
                .ToList();
        }

        public void CrearExamen(Examen examen)
        {
            examen.EstaActivo = true;
            examen.UsuarioId = session.ConvertirSessionIdAIntId();
            examen.FechaCreacion = DateTime.Now;
            conexion.Examenes.Add(examen);
            conexion.SaveChanges();
        }
    }
}