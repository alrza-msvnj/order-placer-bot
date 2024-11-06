using OpenQA.Selenium;

namespace AutoOrder.Controllers
{
    public class Logout
    {
        #region Fields

        private readonly IWebDriver _webDriver;
        private readonly string _baseSiteUrl;

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
