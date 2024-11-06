using OpenQA.Selenium;

namespace AutoOrder.Methods
{
    public class Logout
    {
        #region Fields

        public readonly IWebDriver _webDriver;
        public readonly string _baseSiteUrl;

        #endregion

        #region Ctor

        public Logout(IWebDriver webDriver, string baseSiteUrl)
        {
            _webDriver = webDriver;
            _baseSiteUrl = baseSiteUrl;
        }

        #endregion

        #region Methods

        public void DoLogout()
        {
            _webDriver.Navigate().GoToUrl($"{_baseSiteUrl}logout");
        }

        #endregion
    }
}
