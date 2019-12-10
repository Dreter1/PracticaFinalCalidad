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
    class PreguntasControllerTest
    {
        [Test]
        public void TestPreguntasIndex()
        {
            var servicePreguntaMock = new Mock<IPreguntasService>();
            var serviceTemaMock = new Mock<ITemasServices>();

            serviceTemaMock.Setup(o => o.GetTemaById(1)).Returns(new Tema());

            var controlador = new PreguntaController(servicePreguntaMock.Object, serviceTemaMock.Object);
            var vista = controlador.Index(1);
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestPreguntasCrear()
        {
            var servicePreguntaMock = new Mock<IPreguntasService>();
            var serviceTemaMock = new Mock<ITemasServices>();

            var controlador = new PreguntaController(servicePreguntaMock.Object, serviceTemaMock.Object);
            var vista = controlador.Crear(1);
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestPreguntasCrearForm()
        {
            var servicePreguntaMock = new Mock<IPreguntasService>();
            var serviceTemaMock = new Mock<ITemasServices>();

            var controlador = new PreguntaController(servicePreguntaMock.Object, serviceTemaMock.Object);
            var vista = controlador.Crear(new Pregunta {
                Id = 1,
                Descripcion = "PreguntaMock",
                Alternativas = new List<Alternativa>
                {
                    new Alternativa { Id = 1,Descripcion = "mock",EsCorrecto = true, PreguntaId = 1},
                    new Alternativa { Id = 2,Descripcion = "mock",EsCorrecto = false, PreguntaId = 1},
                    new Alternativa { Id = 3,Descripcion = "mock",EsCorrecto = false, PreguntaId = 1},
                    new Alternativa { Id = 4,Descripcion = "mock",EsCorrecto = false, PreguntaId = 1},
                },
                TemaId = 1
            });
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }

        [Test]
        public void TestPreguntasCrearFormEmpty()
        {
            var servicePreguntaMock = new Mock<IPreguntasService>();
            var serviceTemaMock = new Mock<ITemasServices>();

            var controlador = new PreguntaController(servicePreguntaMock.Object, serviceTemaMock.Object);
            var vista = controlador.Crear(new Pregunta
            {
                Id = 1,
                Descripcion = "PreguntaMock",
                TemaId = 1
            });
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestPreguntasEditar()
        {
            var servicePreguntaMock = new Mock<IPreguntasService>();
            var serviceTemaMock = new Mock<ITemasServices>();

            servicePreguntaMock.Setup(o => o.GetPreguntaById(1)).Returns(new Pregunta());

            var controlador = new PreguntaController(servicePreguntaMock.Object, serviceTemaMock.Object);
            var vista = controlador.Editar(1);
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void TestPreguntasEditarForm()
        {
            var servicePreguntaMock = new Mock<IPreguntasService>();
            var serviceTemaMock = new Mock<ITemasServices>();

            var controlador = new PreguntaController(servicePreguntaMock.Object, serviceTemaMock.Object);
            var vista = controlador.Editar(new Pregunta {
                Id = 1,
                Descripcion = "mock",
                TemaId = 1
            });
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }

        [Test]
        public void TestPreguntasEliminar()
        {
            var servicePreguntaMock = new Mock<IPreguntasService>();
            var serviceTemaMock = new Mock<ITemasServices>();

            var controlador = new PreguntaController(servicePreguntaMock.Object, serviceTemaMock.Object);
            var vista = controlador.Eliminar(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }
    }
}
