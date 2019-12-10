using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public class CategoriaService : ICategoriaService
    {
        private readonly SimuladorContext conexion;

        public CategoriaService(SimuladorContext conexion)
        {
            this.conexion = conexion;
        }

        public List<Categoria> GetCategoriaAsList()
        {
            return conexion.Categorias.ToList();
        }
    }
}