using OpenQA.Selenium;


namespace IntISsoftTestQAFramework.Pages
{
    public abstract class IntPlBasePage
    {
        public const string MAIN_PAGE = "https://int.pl/";
        public const string MAIL_PAGE = "https://poczta.int.pl/";
        public const string LOGIN_PAGE = "https://login.yahoo.com/";


        IWebDriver _webDriver;


        public IntPlBasePage(IWebDriver webDriver, string url)
        {
            _webDriver = webDriver;
            _webDriver.Url = url;
            _webDriver.Manage().Window.Maximize();
        }

    }
}
