using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interfaces
{
    public interface ITemaCategoriaService
    {
        void Crear(Tema tema, List<int> Ids);
    }
}
