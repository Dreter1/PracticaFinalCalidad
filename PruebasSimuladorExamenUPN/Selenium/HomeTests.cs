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
    class HomeTests
    {
        string RutaGlobal = "http://localhost:58972/";
        ChromeOptions opciones = new ChromeOptions();

        [Test]
        public void HomeIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            var pageId = navegador.FindElementById("IndexHomeLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void HomeTomarExamenTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();

            navegador.FindElementById("HomeTomarExamenLink").Click();

            var pageId = navegador.FindElementById("ConfirmarHomeLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void HomeConfirmarExamenTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("HomeTomarExamenLink").Click();
            navegador.FindElementById("IniciarExamenHomeLink").Click();

            var pageId = navegador.FindElementById("DarExamenHomeLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void HomeConfirmarExamenCancelarTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("IngresarSistemaLink").Click();
            navegador.FindElementById("HomeTomarExamenLink").Click();
            navegador.FindElementById("CancelarExamenHomeLink").Click();

            var pageId = navegador.FindElementById("IndexHomeLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }
    }
}
