using Moq;
using NUnit.Framework;
using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using SimuladorExamenUPN.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSimuladorExamenUPN.Unitarias.Servicios
{
    [TestFixture]
    class PreguntasServiceTest
    {
        [Test]
        public void PreguntaGetPreguntaById()
        {
            var datos = new List<Pregunta> {
                new Pregunta { Id = 1, Descripcion = "Holita"},
                new Pregunta { Id = 2, Descripcion = "Pel2"},
                new Pregunta { Id = 3, Descripcion = "Pel3"}
            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Pregunta>>();
            dbSet.As<IQueryable<Pregunta>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Pregunta>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Pregunta>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Pregunta>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Preguntas).Returns(dbSet.Object);
            var service = new PreguntasService(contex.Object);
            var pregunta = service.GetPreguntaById(1);
            Assert.AreEqual(1, pregunta.Id);
        }

        [Test]
        public void PreguntaGenerarPreguntasAsList()
        {
            var datos = new List<Pregunta> {
                new Pregunta { Id = 1, Descripcion = "MOck", TemaId = 1},
                new Pregunta { Id = 2, Descripcion = "MOck", TemaId = 2},
                new Pregunta { Id = 3, Descripcion = "MOck", TemaId = 2},
                new Pregunta { Id = 4, Descripcion = "MOck", TemaId = 1},
                new Pregunta { Id = 5, Descripcion = "MOck", TemaId = 1},
                new Pregunta { Id = 6, Descripcion = "MOck", TemaId = 1}
            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Pregunta>>();
            dbSet.As<IQueryable<Pregunta>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Pregunta>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Pregunta>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Pregunta>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Preguntas).Returns(dbSet.Object);
            var service = new PreguntasService(contex.Object);
            var pregunta = service.GenerarPreguntas(1,5);
            Assert.AreEqual(4, pregunta.Count);
        }
    }
}
