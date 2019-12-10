using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public class SessionService : ISessionService
    {

        private readonly HttpContext contexto;

        public SessionService()
        {
            contexto = HttpContext.Current;
        }

        public void GuardarSesion(Usuario Usuario)
        {
            contexto.Session["UsuarioId"] = Usuario.Id.ToString();
        }

        public void LimpiarSesion()
        {
            contexto.Session.Clear();
        }

        public bool IsLogged()
        {
            if (contexto.Session["UsuarioId"] != null)
                return true;

            return false;
        }

        public int ConvertirSessionIdAIntId()
        {
            int UsuarioId = Convert.ToInt32(contexto.Session["UsuarioId"]);
            return UsuarioId;
        }
    }
}