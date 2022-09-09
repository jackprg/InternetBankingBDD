using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;


namespace InternetBanking.BDD.Tests
{
    [Binding]
    public class EnviarPixStepDefinitions
    {
        private IWebDriver Browser;

        [BeforeScenario("Robo")]
        public void CreateWebDriver()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();

            ChromeOptions chromeOpts = new ChromeOptions();
            chromeOpts.AddArgument("--headless");

            Browser = new ChromeDriver(service, chromeOpts);
        }


        [AfterScenario("Robo")]
        public void CloseWebDriver()
        {
            Browser.Close();
            Browser.Dispose();
        }


        [Given(@"que sou um usuário do Internet Banking")]
        public void GivenQueSouUmUsuarioDoInternetBanking()
        {
            Browser.Navigate().GoToUrl("http://localhost:5230");
        }

        [Given(@"acessei a feature de envio de pix")]
        public void GivenAcesseiAFeatureDeEnvioDePix()
        {
            Browser.Navigate().GoToUrl("http://localhost:5230/Pix/Enviar");
        }

        [Given(@"selecionei o tipo de chave")]
        public void GivenSelecioneiOTipoDeChave()
        {
            var selectTipoChave = new SelectElement(Browser.FindElement(By.Id("tipoChave")));

            selectTipoChave.SelectByValue("CPF");
        }

        [Given(@"informei a chave")]
        public void GivenInformeiAChave()
        {
            var chave = Browser.FindElement(By.Id("chave"));

            chave.SendKeys("62995452590");
        }

        [Given(@"informei o valor")]
        public void GivenInformeiOValor()
        {
            var valor = Browser.FindElement(By.Id("valor"));

            valor.SendKeys("10");
        }

        [When(@"clicar na opção enviar")]
        public void WhenClicarNaOpcaoEnviar()
        {
            var btnEnviar = Browser.FindElement(By.Id("enviar"));
            btnEnviar.Submit();
        }

        [Then(@"o comprovante de pix deve ser exibido")]
        public void ThenOComprovanteDePixDeveSerExibido()
        {
            var valorElement = Browser.FindElement(By.Id("valor"));
            var statusElement = Browser.FindElement(By.Id("status"));
            var bancoDestinoElement = Browser.FindElement(By.Id("bancoDestino"));
            var contaDestinoElement = Browser.FindElement(By.Id("contaDestino"));
            var destinatarioElement = Browser.FindElement(By.Id("destinatario"));


            Assert.IsTrue(valorElement.Text == "10", "Valor é diferente de 10. @ " + valorElement.Text);
            Assert.IsTrue(statusElement.Text == "SUCESSO", "Status é diferente de SUCESSO. @ " + statusElement.Text);
            Assert.IsTrue(bancoDestinoElement.Text == "Caixa Economica Federal", "Banco de destino é diferente de Caixa Economica Federal. @ " + bancoDestinoElement.Text);
            Assert.IsTrue(contaDestinoElement.Text == "224455-6", "Conta de destino é diferente de 224455-6 @ " + contaDestinoElement.Text);
            Assert.IsTrue(destinatarioElement.Text == "Guilherme Correia Santos", "Destinatario Guilherme Correia Santos @ " + destinatarioElement.Text);
        }
    }
}
