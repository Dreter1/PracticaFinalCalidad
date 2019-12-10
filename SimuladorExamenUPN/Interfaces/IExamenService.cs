using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interfaces
{
    public interface IExamenService
    {
        List<Examen> GetExamenAsList();
        Examen GetExamenById(int? ExamenId);
        Examen RealizarExamenById(int? ExamenId);
        List<Examen> GetExamenByUserId(int? UsuarioId);
        void CrearExamen(Examen examen);
    }
}
