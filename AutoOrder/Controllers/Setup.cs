using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoOrder.Models;

namespace AutoOrder.Controllers
{
    public class Setup
    {
        #region Fields

        public Root root;
        public IWebDriver webDriver;
        public string baseSiteUrl = "https://www.rubeston.com/";
        public IJavaScriptExecutor javaScriptExecutor;

        #endregion

        #region Methods

        public void WebDriverSetup()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(baseSiteUrl);

            javaScriptExecutor = (IJavaScriptExecutor)webDriver;
        }

        //public void TearDown()
        //{
        //    webDriver.Quit();
        //}

        #endregion
    }
}
