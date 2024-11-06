using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutoOrder.Models;

namespace AutoOrder.Methods
{
    public class Shipping
    {
        #region Fields

        public readonly IWebDriver _webDriver;
        public readonly string _baseSiteUrl;

        #endregion

        #region Ctor

        public Shipping(IWebDriver webDriver, string baseSiteUrl)
        {
            _webDriver = webDriver;
            _baseSiteUrl = baseSiteUrl;
        }

        #endregion

        #region Methods

        public void DoShipping(Address address)
        {
            _webDriver.Navigate().GoToUrl($"{_baseSiteUrl}cart");

            _webDriver.FindElement(By.Name("checkout")).Click();

            try
            {
                var existingAddress = _webDriver.FindElement(By.CssSelector("div.km-address-style.km-active"));
            }
            catch (NoSuchElementException)
            {
                _webDriver.FindElement(By.CssSelector("div.km-address-style-add")).Click();
                _webDriver.FindElement(By.Id("txtAddrName")).SendKeys(address.Name);
                _webDriver.FindElement(By.Id("txtAddrNameLast")).SendKeys(address.LastName);
                _webDriver.FindElement(By.Id("txtAddrMobile")).SendKeys(address.Mobile);
                _webDriver.FindElement(By.Id("txtAddrNationalCode")).SendKeys(address.NationalCode);

                Thread.Sleep(1000);
                var selectProvince = new SelectElement(_webDriver.FindElement(By.Id("BillingNewAddress_StateProvinceId")));
                selectProvince.SelectByText(address.Province);

                Thread.Sleep(1000);
                var selectCity = new SelectElement(_webDriver.FindElement(By.Id("BillingNewAddress_City")));
                selectCity.SelectByText(address.City);

                Thread.Sleep(1000);
                var selectArea = new SelectElement(_webDriver.FindElement(By.Id("BillingNewAddress_RegionAreaId")));
                selectArea.SelectByText(address.Area);

                _webDriver.FindElement(By.Id("txtAddrDescription")).SendKeys(address.PostalAddress);
                _webDriver.FindElement(By.Id("txtAddrPostalCode")).SendKeys(address.PostalCode);

                _webDriver.FindElement(By.CssSelector("button.km-btn.km-color1.km-theme-3.width-100.btnSubmitLight")).Click();
            }
        }

        #endregion
    }
}
