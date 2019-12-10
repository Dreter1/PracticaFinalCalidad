using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SimuladorContext conexion;

        public UsuarioService(SimuladorContext conexion)
        {
            this.conexion = conexion;
        }

        public Usuario GetUsuarioByCorreoAndClave(string username, string password)
        {
            Usuario usuario = conexion.Usuarios.Where(u => u.Username == username).FirstOrDefault();

            if (usuario == null)
                return null;

           return usuario;
        }
    }
}