using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSimuladorExamenUPN.Selenium
{
    [TestFixture]
    class TemaTest
    {
        string RutaGlobal = "http://localhost:58972/";
        ChromeOptions opciones = new ChromeOptions();

        [Test]
        public void TemaIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            var pageId = navegador.FindElementById("IndexTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaCrearIndextest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("creartemaLink").Click();
            var pageId = navegador.FindElementById("CrearTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaCrearFormTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("creartemaLink").Click();

            navegador.FindElementById("CrearNombreTema").SendKeys("Prueba");
            navegador.FindElementById("CrearCategoriaTema").SendKeys("Historia");
            navegador.FindElementById("CrearDescripcionTema").SendKeys("Probando");
            navegador.FindElementById("CrearTemaLink").Click();

            var pageId = navegador.FindElementById("IndexTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaCrearFormCancelarTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("creartemaLink").Click();

            navegador.FindElementById("CrearNombreTema").SendKeys("Prueba");
            navegador.FindElementById("CrearCategoriaTema").SendKeys("Historia");
            navegador.FindElementById("CrearDescripcionTema").SendKeys("Probando");
            navegador.FindElementById("CancelarCrearTemaLink").Click();

            var pageId = navegador.FindElementById("IndexTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaCrearFormEmptyTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("creartemaLink").Click();
            navegador.FindElementById("CrearTemaLink").Click(); 
             var pageId = navegador.FindElementById("CrearTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaEditarTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("EditarTemaLink_3").Click();
            var pageId = navegador.FindElementById("EditarTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaEditarFormTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("EditarTemaLink_3").Click();

            navegador.FindElementById("EditarNombreTema").Clear();
            navegador.FindElementById("EditarNombreTema").SendKeys("NuevoNombre");
            navegador.FindElementById("EditarTemaLink").Click();

            var pageId = navegador.FindElementById("IndexTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaEditarFormCancelarTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("EditarTemaLink_3").Click();

            navegador.FindElementById("EditarNombreTema").Clear();
            navegador.FindElementById("EditarNombreTema").SendKeys("NuevoNombre");
            navegador.FindElementById("CancelarEditarTemaLink").Click();

            var pageId = navegador.FindElementById("IndexTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaEditarFormEmptyTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("EditarTemaLink_3").Click();

            navegador.FindElementById("EditarNombreTema").Clear();
            navegador.FindElementById("EditarDescripcionTema").Clear();
            navegador.FindElementById("EditarTemaLink").Click();

            var pageId = navegador.FindElementById("EditarTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaEliminarTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("EliminarTemaLink_1017").Click();

            var pageId = navegador.FindElementById("IndexTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void TemaPreguntasTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("PreguntaTemaLink_3").Click();

            var pageId = navegador.FindElementById("IndexPreguntaLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }
    }
}
