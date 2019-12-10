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
    class PreguntasTest
    {
        string RutaGlobal = "http://localhost:58972/";
        ChromeOptions opciones = new ChromeOptions();

        [Test]
        public void PreguntasIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("PreguntaTemaLink_1").Click();

            var pageId = navegador.FindElementById("IndexPreguntaLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void PreguntasIrATemaTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("PreguntaTemaLink_1").Click();
            navegador.FindElementById("IrTemasLink").Click();

            var pageId = navegador.FindElementById("IndexTemasLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void PreguntasCrearTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("PreguntaTemaLink_1").Click();
            navegador.FindElementById("CrearIndexPreguntaLink").Click();

            var pageId = navegador.FindElementById("CrearPreguntaLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void PreguntasCrearFormTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("temaLink").Click();
            navegador.FindElementById("PreguntaTemaLink_1").Click();
            navegador.FindElementById("CrearIndexPreguntaLink").Click();
            navegador.FindElementById("CancelarCrearPreguntaLink").Click();

            var pageId = navegador.FindElementById("IndexPreguntaLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }
    }
}
