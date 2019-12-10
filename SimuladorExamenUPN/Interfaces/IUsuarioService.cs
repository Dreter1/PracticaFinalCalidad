using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interfaces
{
    public interface IUsuarioService
    {
        Usuario GetUsuarioByCorreoAndClave(string username, string password);
    }
}
