using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class CT01ValidarLayoutTela
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://inoveteste.com.br/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheCT01ValidarLayoutTelaTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/contato/");
            Assert.AreEqual("Envie uma mensagem", driver.FindElement(By.CssSelector("h1")).Text);
            Assert.AreEqual("Nome", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("E-mail", driver.FindElement(By.XPath("//div[@id='wpcf7-f372-p24-o1']/form/p[2]/label")).Text);
            Assert.AreEqual("Assunto", driver.FindElement(By.XPath("//div[@id='wpcf7-f372-p24-o1']/form/p[3]/label")).Text);
            Assert.AreEqual("Mensagem", driver.FindElement(By.XPath("//div[@id='wpcf7-f372-p24-o1']/form/p[4]/label")).Text);
            Assert.AreEqual("Enviar", driver.FindElement(By.CssSelector("input.wpcf7-form-control.wpcf7-submit")).GetAttribute("value"));
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
