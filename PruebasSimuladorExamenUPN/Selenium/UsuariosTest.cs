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
    class UsuariosTest
    {
        string RutaGlobal = "http://localhost:58972/";
        ChromeOptions opciones = new ChromeOptions();

        [Test]
        public void LoginTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            var pageId = navegador.FindElementById("LoginUsuarioLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void LoginTestForm()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;

            navegador.FindElementById("UsuarioIngresoLink").Clear();
            navegador.FindElementById("ClaveIngresoLink").Clear();

            navegador.FindElementById("UsuarioIngresoLink").SendKeys("admin");
            navegador.FindElementById("ClaveIngresoLink").SendKeys("admin");
            navegador.FindElementById("IngresarSistemaLink").Click();

            var pageId = navegador.FindElementById("IndexHomeLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }

        [Test]
        public void LoginTestFormEmpty()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;

            navegador.FindElementById("UsuarioIngresoLink").Clear();
            navegador.FindElementById("ClaveIngresoLink").Clear();
            navegador.FindElementById("IngresarSistemaLink").Click(); 

            var pageId = navegador.FindElementById("ValidacionLink");
            Assert.IsNotNull(pageId);
            navegador.Close();
        }
    }
}
