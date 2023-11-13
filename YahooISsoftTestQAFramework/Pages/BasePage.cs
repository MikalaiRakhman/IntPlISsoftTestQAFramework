using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IntISsoftTestQAFramework.Pages
{
    public abstract class BasePage
    {
        IWebDriver _driver;
        public BasePage(IWebDriver driver,  string url)
        {
            _driver = driver;
            _driver.Url = url;
            _driver.Manage().Window.Maximize();            
        }
    }
}
