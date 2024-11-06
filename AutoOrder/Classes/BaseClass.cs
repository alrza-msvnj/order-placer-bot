using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;
using AutoOrder.Models;

namespace AutoOrder.Methods
{
    public class BaseClass
    {
        public Root root;
        public IWebDriver webDriver;
        public string baseSiteUrl = "https://www.rubeston.com/";
        public IJavaScriptExecutor javaScriptExecutor;

        public void SetUp()
        {
            root = new Root();
            var ordersPath = Path.Combine(Environment.CurrentDirectory + @"\..\..\..\Orders.json");
            var ordersJson = File.ReadAllText(ordersPath);
            root.Orders = JsonConvert.DeserializeObject<List<Order>>(ordersJson);

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
    }
}
