using OpenQA.Selenium;
using AutoOrder.Models;

namespace AutoOrder.Controllers
{
    public class Order
    {
        #region Fields

        private readonly IWebDriver _webDriver;
        private readonly string _baseSiteUrl;
        private readonly IJavaScriptExecutor _javaScriptExecutor;

        #endregion

        #region Ctor

        public Order(IWebDriver webDriver, string baseSiteUrl, IJavaScriptExecutor javaScriptExecutor)
        {
            _webDriver = webDriver;
            _baseSiteUrl = baseSiteUrl;
            _javaScriptExecutor = javaScriptExecutor;
        }

        #endregion

        #region Methods

        public void DoOrder(List<Product> products)
        {
            foreach (var product in products)
            {
                _webDriver.Navigate().GoToUrl($"{_baseSiteUrl}product/vp-{product.ProductId}/");

                try
                {
                    for (int i = 1; i < product.Quantity; i++)
                    {
                        _javaScriptExecutor.ExecuteScript("arguments[0].click();", _webDriver.FindElement(By.CssSelector("div.km-product-left-left.sticky-mode span.vp-btn.vp-plus")));
                    }

                    _webDriver.FindElement(By.CssSelector("span.title-add-to-cart.p-t-2")).Click();
                }
                catch (NoSuchElementException)
                {
                }
            }
        }

        #endregion
    }
}