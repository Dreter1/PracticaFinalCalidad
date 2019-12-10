using Moq;
using NUnit.Framework;
using SimuladorExamenUPN.Controllers;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Manager;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebasSimuladorExamenUPN.Unitarias.Controladores
{
    [TestFixture]
    class UsuarioControllerTest
    {
        [Test]
        public void TestUsuarioLogin()
        {
            var serviceUsuarioMock = new Mock<IUsuarioService>();
            var serviceAutManagerMock = new Mock<IAutManager>();
            var serviceSessionMock = new Mock<ISessionService>();

            var controlador = new UsuarioController(serviceSessionMock.Object, serviceAutManagerMock.Object, serviceUsuarioMock.Object);
            var vista = controlador.Login();
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestUsuarioLoginForm()
        {
            var serviceUsuarioMock = new Mock<IUsuarioService>();
            var serviceAutManagerMock = new Mock<IAutManager>();
            var serviceSessionMock = new Mock<ISessionService>();

            serviceUsuarioMock.Setup(u => u.GetUsuarioByCorreoAndClave("admin", "admin")).Returns(new Usuario() { Id = 1 });
            var controlador = new UsuarioController(serviceSessionMock.Object, serviceAutManagerMock.Object, serviceUsuarioMock.Object);
            controlador.ControllerContext = FakeHttpContext();
            var vista = controlador.Login("admin","admin");
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }

        [Test]
        public void TestUsuarioFormEmpty()
        {
            var serviceUsuarioMock = new Mock<IUsuarioService>();
            var serviceAutManagerMock = new Mock<IAutManager>();
            var serviceSessionMock = new Mock<ISessionService>();

            var controlador = new UsuarioController(serviceSessionMock.Object, serviceAutManagerMock.Object, serviceUsuarioMock.Object);
            var vista = controlador.Login("","");
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        public ControllerContext FakeHttpContext()
        {
            var cContext = new Mock<ControllerContext>();
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new MockHttpSession();
            var server = new Mock<HttpServerUtilityBase>();

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session);
            context.Setup(ctx => ctx.Server).Returns(server.Object);

            cContext.Setup(p => p.HttpContext).Returns(context.Object);
            return cContext.Object;
        }

        public class MockHttpSession : HttpSessionStateBase
        {
            Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();

            public override object this[string name]
            {
                get { return m_SessionStorage[name]; }
                set { m_SessionStorage[name] = value; }
            }
        }

    }
}
