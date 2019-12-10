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
    class HomeControllerTest
    {
        [Test]
        public void TestHomeIndex()
        {
            var serviceExamenMock = new Mock<IExamenService>();

            var controlador = new HomeController(serviceExamenMock.Object);
            var vista = controlador.Index();
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestHomeConfirmar()
        {
            var serviceExamenMock = new Mock<IExamenService>();

            serviceExamenMock.Setup(o => o.GetExamenById(1)).Returns(new Examen());

            var controlador = new HomeController(serviceExamenMock.Object);
            var vista = controlador.Confirmar(1);
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestHomeDarExamen()
        {
            var serviceExamenMock = new Mock<IExamenService>();

            serviceExamenMock.Setup(o => o.RealizarExamenById(1)).Returns(new Examen());

            var controlador = new HomeController(serviceExamenMock.Object);
            var vista = controlador.DarExamen(1);
            Assert.IsInstanceOf<ViewResult>(vista);
        }
    }
}
