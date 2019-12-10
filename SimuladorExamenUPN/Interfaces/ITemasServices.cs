using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interfaces
{
    public interface ITemasServices
    {
        List<Tema> GetTemaAsList();
        List<Tema> GetTemaAsListByCriterio(string criterio);
        Tema GetTemaById(int temaId);
        Tema GetTemasAsListWithPreguntasId(int temaId);
        void Crear(Tema tema);
        void Editar(Tema tema);
        void Eliminar(int id);
    }
}
