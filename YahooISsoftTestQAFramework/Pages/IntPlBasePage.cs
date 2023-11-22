using OpenQA.Selenium;


namespace IntISsoftTestQAFramework.Pages
{
    public abstract class IntPlBasePage
    {
        IWebDriver _webDriver;
        public IntPlBasePage(IWebDriver webDriver, string url)
        {
            _webDriver = webDriver;
            _webDriver.Url = url;
            _webDriver.Manage().Window.Maximize();
        }
    }
}
