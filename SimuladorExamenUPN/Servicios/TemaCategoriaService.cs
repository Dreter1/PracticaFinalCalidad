using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public class TemaCategoriaService : ITemaCategoriaService
    {
        private readonly SimuladorContext conexion;

        public TemaCategoriaService(SimuladorContext conexion)
        {
            this.conexion = conexion;
        }

        public void Crear(Tema tema, List<int> Ids)
        {
            foreach (var categoriaid in Ids)
            {
                var temaCategoria = new TemaCategoria() { CategoriaId = categoriaid, TemaId = tema.Id };
                conexion.TemaCategorias.Add(temaCategoria);
                conexion.SaveChanges();
            }
        }
    }
}