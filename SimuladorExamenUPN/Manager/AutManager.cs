using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SimuladorExamenUPN.Manager
{
    public class AutManager : IAutManager
    {
        public void Login(Usuario Usuario)
        {
            FormsAuthentication.SetAuthCookie(Usuario.Username, false);
            HttpContext.Current.Session["Usuario"] = Usuario;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public Usuario GetLoggedUser()
        {
            return (Usuario)HttpContext.Current.Session["Usuario"];
        }

    }
}