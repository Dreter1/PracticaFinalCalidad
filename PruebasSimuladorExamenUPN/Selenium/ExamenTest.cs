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
    class ExamenTest
    {
        string RutaGlobal = "http://localhost:58972/";
        ChromeOptions opciones = new ChromeOptions();

        [Test]
        public void ExamenIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("examenesLink").Click(); 
            var pageId = navegador.FindElementById("IndexExamen");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void ExamenCrearIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("examenesLink").Click();
            navegador.FindElementById("CrearExamen").Click();
            var pageId = navegador.FindElementById("CrearExamenLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void ExamenCrearFormTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("examenesLink").Click();
            navegador.FindElementById("CrearExamen").Click();

            navegador.FindElementById("TemaSelectExamenCrearLink").SendKeys("Primera Guerra Mundial 1");
            navegador.FindElementById("PreguntasCrearExamenLink").SendKeys("5");
            navegador.FindElementById("GuardarCrearExamenLink").Click();

            var pageId = navegador.FindElementById("IndexExamen");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void ExamenCrearFormCancelarTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("examenesLink").Click();
            navegador.FindElementById("CrearExamen").Click();

            navegador.FindElementById("TemaSelectExamenCrearLink").SendKeys("Primera Guerra Mundial 1");
            navegador.FindElementById("PreguntasCrearExamenLink").SendKeys("5");
            navegador.FindElementById("CancelarCrearExamenLink").Click();

            var pageId = navegador.FindElementById("IndexExamen");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void ExamenCrearFormEmptyTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("examenesLink").Click();
            navegador.FindElementById("CrearExamen").Click();

            navegador.FindElementById("PreguntasCrearExamenLink").SendKeys("5");
            navegador.FindElementById("GuardarCrearExamenLink").Click();

            var pageId = navegador.FindElementById("CrearExamenLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }
    }
}
