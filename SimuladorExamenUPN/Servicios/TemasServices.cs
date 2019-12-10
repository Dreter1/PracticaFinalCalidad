using SimuladorExamenUPN.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimuladorExamenUPN.Models;
using SimuladorExamenUPN.Interfaces;
using System.Data.Entity;

namespace SimuladorExamenUPN.Servicios
{
    public class TemasServices : ITemasServices
    {
        private readonly SimuladorContext conexion;

        public TemasServices(SimuladorContext conexion)
        {
            this.conexion = conexion;
        }

        public List<Tema> GetTemaAsList()
        {
            return conexion.Temas.ToList();
        }

        public List<Tema> GetTemaAsListByCriterio(string criterio)
        {
            var temas = conexion.Temas.Include(a => a.Categorias.Select(o => o.Categoria)).AsQueryable();

            if (!string.IsNullOrEmpty(criterio))
                temas = temas.Where(o => o.Nombre.Contains(criterio));

            return temas.ToList();
        }

        public Tema GetTemaById(int temaId)
        {
            return conexion.Temas.Where(o => o.Id == temaId).FirstOrDefault();
        }

        public Tema GetTemasAsListWithPreguntasId(int temaId)
        {
            return conexion.Temas
                .Include(o => o.Preguntas.Select(x => x.Alternativas))
                .Where(x => x.Id == temaId)
                .FirstOrDefault();
        }

        public void Crear(Tema tema)
        {
            conexion.Temas.Add(tema);
            conexion.SaveChanges();
        }

        public void Editar(Tema tema)
        {
            conexion.Entry(tema).State = EntityState.Modified;
            conexion.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Tema tema = GetTemaById(id);
            conexion.Temas.Remove(tema);
            conexion.SaveChanges();
        }
    }
}