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
    public class PreguntasService : IPreguntasService
    {
        private readonly SimuladorContext conexion;

        public PreguntasService(SimuladorContext conexion)
        {
            this.conexion = conexion;
        }

        public Pregunta GetPreguntaById(int PreguntaId)
        {
            return conexion.Preguntas.Where(o => o.Id == PreguntaId).FirstOrDefault();
        }

        public List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas)
        {
            var basePreguntas = conexion.Preguntas.Where(o => o.TemaId == tema).ToList();
            return basePreguntas
                .OrderBy(x => Guid.NewGuid())
                .Take(nroPreguntas).ToList();
        }

        public void GuardarPreguntas(Examen examen, List<Pregunta> preguntas)
        {
            foreach (var item in preguntas)
            {
                var examenPreguta = new ExamenPregunta();
                examenPreguta.ExamenId = examen.Id;
                examenPreguta.PreguntaId = item.Id;
                conexion.ExamenPreguntas.Add(examenPreguta);       
                conexion.SaveChanges();
            }
        }

        public void CrearPregunta(Pregunta pregunta)
        {
            conexion.Preguntas.Add(pregunta);
            conexion.SaveChanges();
        }

        public void EditarPregunta(Pregunta pregunta)
        {
            conexion.Entry(pregunta).State = EntityState.Modified;
            conexion.SaveChanges();
        }

        public void EliminarPregunta(int PreguntaId)
        {
            var pregunta = GetPreguntaById(PreguntaId);
            conexion.Preguntas.Remove(pregunta);
            conexion.SaveChanges();
        }
    }
}