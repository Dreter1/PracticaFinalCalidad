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
    class CategoriaServiceTest
    {
        [Test]
        public void CategoriaGetCategoriasAsList()
        {
            var datos = new List<Categoria> {
                new Categoria { Id = 1, Nombre = "MockCate1" },
                new Categoria { Id = 2, Nombre = "MockCate2" },
                new Categoria { Id = 3, Nombre = "MockCate3" },
            }.AsQueryable();

            var dbSet = new Mock<IDbSet<Categoria>>();
            dbSet.As<IQueryable<Categoria>>().Setup(m => m.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Categoria>>().Setup(m => m.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Categoria>>().Setup(m => m.ElementType).Returns(datos.ElementType);
            dbSet.As<IQueryable<Categoria>>().Setup(m => m.GetEnumerator()).Returns(datos.GetEnumerator());

            var contex = new Mock<SimuladorContext>();
            contex.Setup(o => o.Categorias).Returns(dbSet.Object);

            var service = new CategoriaService(contex.Object);
            var categoria = service.GetCategoriaAsList();
            Assert.AreEqual(3, categoria.Count);
        }
    }
}
