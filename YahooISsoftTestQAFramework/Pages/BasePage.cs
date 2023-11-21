using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace IntISsoftTestQAFramework.Pages
{
    public abstract class BasePage
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        Actions _actions;
        public BasePage(IWebDriver driver, WebDriverWait wait, Actions actions, string url)
        {
            _driver = driver;
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
            _wait = wait;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            _actions = actions;
            _actions = new Actions(driver);
        }            
        public void RefreshPage() 
        {
            _driver.Navigate().Refresh();
        }

        public void FindElement(string elementXPath) 
        {           
            _driver.FindElement(By.XPath(elementXPath));
        }

        public void WaitUntilElementIsVisible(string elementXPath) 
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(elementXPath)));
        }
        public void ClickOnElementByXPath(string elementXPath) 
        {
            WaitUntilElementIsVisible(elementXPath);
            _driver.FindElement(By.XPath(elementXPath)).Click();
        }
        public void ClickOnElementByClassName(string className)
        {
            WaitUntilElementIsVisible(className);
            _driver.FindElement(By.XPath(className)).Click();
        }
        public void SendKeys(string textKey) 
        {
            _actions.SendKeys(textKey);
        }
        public IWebElement Element(string elementXPath) 
        {
            return _driver.FindElement(By.XPath(elementXPath));
        }
        public bool FindTheTextInTheFrame(string text, string xPath)
        {
            var frame = _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(xPath)));
            return frame.PageSource.ToString().Contains(text);
        }
        public bool IsElementDisplayed(string xPath) 
        {
           return _driver.FindElement(By.XPath(xPath)).Displayed;
        }        
    }
}
