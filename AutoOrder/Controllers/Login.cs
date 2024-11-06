using OpenQA.Selenium;
using AutoOrder.Models;

namespace AutoOrder.Controllers
{
    public class Login
    {
        #region Fields

        private readonly IWebDriver _webDriver;
        private readonly string _baseSiteUrl;

        #endregion

        #region Ctor

        public Login(IWebDriver webDriver, string baseSiteUrl)
        {
            _webDriver = webDriver;
            _baseSiteUrl = baseSiteUrl;
        }

        #endregion

        #region Methods

        public void DoLogin(Customer customer)
        {
            _webDriver.Navigate().GoToUrl(_baseSiteUrl);

            _webDriver.FindElement(By.Id("vp-title-inner-login")).Click();
            _webDriver.FindElement(By.Id("vp-login-otp-mobile")).SendKeys(customer.Mobile);
            _webDriver.FindElement(By.CssSelector("button.vp-btn.vp-theme-fluent.width-100")).Click();

            try
            {
                _webDriver.FindElement(By.CssSelector("a.loginByPassword.vp-btn-link.vp-flex-item")).Click();
            }
            catch (NoSuchElementException)
            {
            }

            _webDriver.FindElement(By.Id("vp-login-otp-password")).SendKeys(customer.Password);
            _webDriver.FindElement(By.CssSelector("button.vp-btn.vp-theme-fluent.width-100")).Click();
        }

        #endregion
    }
}
