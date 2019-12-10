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
    class TemaControllerTest
    {
        [Test]
        public void TestTemaIndex()
        {
            var serviceTemaMock = new Mock<ITemasServices>();
            var serviceCategoriaMock = new Mock<ICategoriaService>();
            var serviceCategoriaTemaMock = new Mock<ITemaCategoriaService>();

            var controlador = new TemaController(serviceTemaMock.Object, serviceCategoriaMock.Object, serviceCategoriaTemaMock.Object);
            var vista = controlador.Index("");
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestTemaCrear()
        {
            var serviceTemaMock = new Mock<ITemasServices>();
            var serviceCategoriaMock = new Mock<ICategoriaService>();
            var serviceCategoriaTemaMock = new Mock<ITemaCategoriaService>();

            var controlador = new TemaController(serviceTemaMock.Object, serviceCategoriaMock.Object, serviceCategoriaTemaMock.Object);
            var vista = controlador.Crear();
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestTemaCrearForm()
        {
            var serviceTemaMock = new Mock<ITemasServices>();
            var serviceCategoriaMock = new Mock<ICategoriaService>();
            var serviceCategoriaTemaMock = new Mock<ITemaCategoriaService>();

            var controlador = new TemaController(serviceTemaMock.Object, serviceCategoriaMock.Object, serviceCategoriaTemaMock.Object);
            var vista = controlador.Crear(new Tema {
                Id = 1,
                Nombre = "Mock",
                Descripcion = "Mock",         
            }, new List<int> {1,2,3,4});
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }

        [Test]
        public void TestTemaCrearFormEmpty()
        {
            var serviceTemaMock = new Mock<ITemasServices>();
            var serviceCategoriaMock = new Mock<ICategoriaService>();
            var serviceCategoriaTemaMock = new Mock<ITemaCategoriaService>();

            var controlador = new TemaController(serviceTemaMock.Object, serviceCategoriaMock.Object, serviceCategoriaTemaMock.Object);
            var vista = controlador.Crear(null,null);
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestTemaEditar()
        {
            var serviceTemaMock = new Mock<ITemasServices>();
            var serviceCategoriaMock = new Mock<ICategoriaService>();
            var serviceCategoriaTemaMock = new Mock<ITemaCategoriaService>();

            serviceTemaMock.Setup(o => o.GetTemaById(1)).Returns(new Tema());

            var controlador = new TemaController(serviceTemaMock.Object, serviceCategoriaMock.Object, serviceCategoriaTemaMock.Object);
            var vista = controlador.Editar(1);
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestTemaEditarForm()
        {
            var serviceTemaMock = new Mock<ITemasServices>();
            var serviceCategoriaMock = new Mock<ICategoriaService>();
            var serviceCategoriaTemaMock = new Mock<ITemaCategoriaService>();

            var controlador = new TemaController(serviceTemaMock.Object, serviceCategoriaMock.Object, serviceCategoriaTemaMock.Object);
            var vista = controlador.Editar(new Tema
            {
                Id = 1,
                Nombre = "Mock",
                Descripcion = "Mock",
            });
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }

        [Test]
        public void TestTemaEliminar()
        {
            var serviceTemaMock = new Mock<ITemasServices>();
            var serviceCategoriaMock = new Mock<ICategoriaService>();
            var serviceCategoriaTemaMock = new Mock<ITemaCategoriaService>();

            var controlador = new TemaController(serviceTemaMock.Object, serviceCategoriaMock.Object, serviceCategoriaTemaMock.Object);
            var vista = controlador.Eliminar(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }
    }
}
