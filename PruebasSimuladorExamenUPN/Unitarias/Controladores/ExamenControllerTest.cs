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
    class ExamenControllerTest
    {
        [Test]
        public void TestExamenIndex()
        {
            var serviceSessionMock = new Mock<ISessionService>();
            var serviceExamenMock = new Mock<IExamenService>();
            var serviceTemasMock = new Mock<ITemasServices>();
            var servicePreguntasMock = new Mock<IPreguntasService>();

            serviceSessionMock.Setup(o => o.ConvertirSessionIdAIntId()).Returns(1);
            serviceExamenMock.Setup(o => o.GetExamenByUserId(1)).Returns(new List<Examen>());

            var controlador = new ExamenController(serviceSessionMock.Object, serviceExamenMock.Object, serviceTemasMock.Object, servicePreguntasMock.Object);
            var vista = controlador.Index();
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestExamenCrear()
        {
            var serviceSessionMock = new Mock<ISessionService>();
            var serviceExamenMock = new Mock<IExamenService>();
            var serviceTemasMock = new Mock<ITemasServices>();
            var servicePreguntasMock = new Mock<IPreguntasService>();

            var controlador = new ExamenController(serviceSessionMock.Object, serviceExamenMock.Object, serviceTemasMock.Object, servicePreguntasMock.Object);
            var vista = controlador.Crear();
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestExamenCrearForm()
        {
            var serviceSessionMock = new Mock<ISessionService>();
            var serviceExamenMock = new Mock<IExamenService>();
            var serviceTemasMock = new Mock<ITemasServices>();
            var servicePreguntasMock = new Mock<IPreguntasService>();

            servicePreguntasMock.Setup(o => o.GenerarPreguntas(1, 2)).Returns(new List<Pregunta>());

            var controlador = new ExamenController(serviceSessionMock.Object, serviceExamenMock.Object, serviceTemasMock.Object, servicePreguntasMock.Object);
            var vista = controlador.Crear(new Examen {
                Id = 1,
                FechaCreacion = new DateTime(1996,06,06),
                EstaActivo = true,
                TemaId = 1,
                UsuarioId = 1
            }, 2);
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }
    }
}
