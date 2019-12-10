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
    class ExamenServiceTest
    {
        [Test]
        public void ExamenGetExamenAsList()
        {
            var datos = new List<Examen> {
                new Examen { Id = 1, FechaCreacion = new DateTime(2000/12/12) , EstaActivo = true, TemaId = 1,UsuarioId = 1 },
                new Examen { Id = 2, FechaCreacion = new DateTime(2010/12/12) , EstaActivo = false,TemaId = 2 ,UsuarioId = 3 },
                new Examen { Id = 3, FechaCreacion = new DateTime(2011/12/12) , EstaActivo = true, TemaId = 1 ,UsuarioId = 2}

            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Examen>>();
            dbSet.As<IQueryable<Examen>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Examenes).Returns(dbSet.Object);

            var service = new ExamenService(contex.Object);
            var examen = service.GetExamenAsList();
            Assert.AreEqual(2, examen.Count);
        }

        [Test]
        public void ExamenGetExamenById()
        {
            var datos = new List<Examen> {
                new Examen { Id = 1, FechaCreacion = new DateTime(2000/12/12) , EstaActivo = true, TemaId = 1,UsuarioId = 1 },
                new Examen { Id = 2, FechaCreacion = new DateTime(2010/12/12) , EstaActivo = false,TemaId = 2 ,UsuarioId = 3 },
                new Examen { Id = 3, FechaCreacion = new DateTime(2011/12/12) , EstaActivo = true, TemaId = 1 ,UsuarioId = 2}

            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Examen>>();
            dbSet.As<IQueryable<Examen>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Examenes).Returns(dbSet.Object);

            var service = new ExamenService(contex.Object);
            var examen = service.GetExamenById(1);
            Assert.AreEqual(1, examen.Id);
        }

        [Test]
        public void ExamenRealizarExamenById()
        {
            var datos = new List<Examen> {
                new Examen { Id = 1, FechaCreacion = new DateTime(2000/12/12) , EstaActivo = true, TemaId = 1,UsuarioId = 1 },
                new Examen { Id = 2, FechaCreacion = new DateTime(2010/12/12) , EstaActivo = false,TemaId = 2 ,UsuarioId = 3 },
                new Examen { Id = 3, FechaCreacion = new DateTime(2011/12/12) , EstaActivo = true, TemaId = 1 ,UsuarioId = 2}

            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Examen>>();
            dbSet.As<IQueryable<Examen>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Examenes).Returns(dbSet.Object);

            var service = new ExamenService(contex.Object);
            var examen = service.RealizarExamenById(1);
            Assert.AreEqual(1, examen.Id);
        }

        [Test]
        public void ExamenGetExamenByUserId()
        {
            var datos = new List<Examen> {
                new Examen { Id = 1, FechaCreacion = new DateTime(2000/12/12) , EstaActivo = true, TemaId = 1,UsuarioId = 1 },
                new Examen { Id = 2, FechaCreacion = new DateTime(2010/12/12) , EstaActivo = false,TemaId = 2 ,UsuarioId = 3 },
                new Examen { Id = 3, FechaCreacion = new DateTime(2011/12/12) , EstaActivo = true, TemaId = 1 ,UsuarioId = 2},
                new Examen { Id = 4, FechaCreacion = new DateTime(2000/12/12) , EstaActivo = true, TemaId = 1,UsuarioId = 1 }


            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Examen>>();
            dbSet.As<IQueryable<Examen>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Examen>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Examenes).Returns(dbSet.Object);

            var service = new ExamenService(contex.Object);
            var examen = service.GetExamenByUserId(1);
            Assert.AreEqual(2, examen.Count);
        }
    }
}
