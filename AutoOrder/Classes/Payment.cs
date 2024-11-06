using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace AutoOrder.Methods
{
    public class Payment
    {
        #region Fields

        public readonly IWebDriver _webDriver;
        public readonly string _baseSiteUrl;
        public readonly IJavaScriptExecutor _javaScriptExecutor;

        #endregion

        #region Ctor

        public Payment(IWebDriver webDriver, string baseSiteUrl, IJavaScriptExecutor javaScriptExecutor)
        {
            _webDriver = webDriver;
            _baseSiteUrl = baseSiteUrl;
            _javaScriptExecutor = javaScriptExecutor;
        }

        #endregion

        #region Methods

        public void DoPayment(string customerDescription, string gateway)
        {
            _webDriver.Navigate().GoToUrl($"{_baseSiteUrl}payment");

            _webDriver.FindElement(By.Id("CustomerDescription")).SendKeys(customerDescription);
            _javaScriptExecutor.ExecuteScript("arguments[0].click();", _webDriver.FindElement(By.CssSelector($"img[alt*='{gateway}']")));
            _webDriver.FindElement(By.CssSelector("button.km-btn.km-theme-2.width-100.km-add-product-to-cart.vp-loading-btn']")).Click();
            _webDriver.FindElement(By.XPath("//button[contains(text(), 'انصراف')]")).Click();
            Thread.Sleep(8000);

            var url = _webDriver.Url;
            var orderId = Regex.Match(url, @"(\d+)").Value;
        }

        #endregion
    }
}
