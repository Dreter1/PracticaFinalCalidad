using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Manager
{
    public interface IAutManager
    {
        void Login(Usuario Usuario);
        void Logout();
        Usuario GetLoggedUser();
    }
}
