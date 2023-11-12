using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace IntISsoftTestQAFramework.Pages
{
    public abstract class IntPlBasePage
    {
        IWebDriver _driver;
        public IntPlBasePage(IWebDriver driver,  string url)
        {
            _driver = driver;
            _driver.Url = url;
            _driver.Manage().Window.Maximize();            
        }
    }
}
