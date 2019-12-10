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
    class TemaServiceTest
    {
        [Test]
        public void TemasGetTemasAsList()
        {
            var datos = new List<Tema> {
                new Tema { Id = 1, Nombre = "MockCate1",Descripcion = "mock" },
                new Tema { Id = 2, Nombre = "MockCate1",Descripcion = "mock" },
                new Tema { Id = 3, Nombre = "MockCate1",Descripcion = "mock" },
            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Tema>>();
            dbSet.As<IQueryable<Tema>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Temas).Returns(dbSet.Object);

            var service = new TemasServices(contex.Object);
            var temas = service.GetTemaAsList();
            Assert.AreEqual(3, temas.Count);
        }

        [Test]
        public void TemasGetTemasAsListByCriterio()
        {
            var datos = new List<Tema> {
                new Tema { Id = 1, Nombre = "MockCate1",Descripcion = "mock" },
                new Tema { Id = 2, Nombre = "MockCate1",Descripcion = "mock" },
                new Tema { Id = 3, Nombre = "MockCate1",Descripcion = "mock" },
            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Tema>>();
            dbSet.As<IQueryable<Tema>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Temas).Returns(dbSet.Object);

            var service = new TemasServices(contex.Object);
            var temas = service.GetTemaAsListByCriterio("MockCate1");
            Assert.AreEqual(3, temas.Count);
        }

        [Test]
        public void TemasGetTemasById()
        {
            var datos = new List<Tema> {
                new Tema { Id = 1, Nombre = "MockCate1",Descripcion = "mock" },
                new Tema { Id = 2, Nombre = "MockCate1",Descripcion = "mock" },
                new Tema { Id = 3, Nombre = "MockCate1",Descripcion = "mock" },
            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Tema>>();
            dbSet.As<IQueryable<Tema>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Temas).Returns(dbSet.Object);

            var service = new TemasServices(contex.Object);
            var temas = service.GetTemaById(1);
            Assert.AreEqual(1, temas.Id);
        }

        [Test]
        public void TemasGetTemasAsListWithPreguntasId()
        {
            var datos = new List<Tema> {
                new Tema { Id = 1, Nombre = "MockCate1",Descripcion = "mock" },
                new Tema { Id = 2, Nombre = "MockCate1",Descripcion = "mock" },
                new Tema { Id = 3, Nombre = "MockCate1",Descripcion = "mock" },
            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Tema>>();
            dbSet.As<IQueryable<Tema>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Tema>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Temas).Returns(dbSet.Object);

            var service = new TemasServices(contex.Object);
            var temas = service.GetTemasAsListWithPreguntasId(1);
            Assert.AreEqual(1, temas.Id);
        }
    }
}
