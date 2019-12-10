using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interfaces
{
    public interface ISessionService
    {
        void GuardarSesion(Usuario Usuario);
        void LimpiarSesion();
        bool IsLogged();
        int ConvertirSessionIdAIntId();
    }
}
