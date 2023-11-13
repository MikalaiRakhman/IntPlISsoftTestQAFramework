using OpenQA.Selenium;
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

        public bool FindTheTextInTheFrame(string text, string xPath) 
        {
            var frame = _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(xPath)));
            return frame.PageSource.ToString().Contains(text);
        }

    }
}
