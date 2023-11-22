using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System;
namespace IntPlLibrary.PagesL
{
    public abstract class BasePage
    {
        IWebDriver _driver;
        Actions _actions;
        public BasePage(IWebDriver driver, string url)
        {
            _driver = driver;
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
            _actions = new Actions(_driver);
        }
        protected void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }
        protected void FindElement(string elementXPath)
        {
            _driver.FindElement(By.XPath(elementXPath));
        }
        protected void ClickOnElementByXPath(string elementXPath)
        {
            _actions.MoveToElement(Element(elementXPath)).Click().Build().Perform();
        }
        protected void ClickOnElementByClassName(string className)
        {
            _driver.FindElement(By.XPath(className)).Click();
        }
        protected void SendKeys(string textKey)
        {
            _actions.SendKeys(textKey).Build().Perform();
        }
        protected IWebElement Element(string elementXPath)
        {
            return _driver.FindElement(By.XPath(elementXPath));
        }
        protected bool FindTheTextInTheFrame(string text, string xPath)
        {
            var frame = _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(xPath)));
            return frame.PageSource.ToString().Contains(text);
        }
        protected bool IsElementDisplayed(string xPath)
        {
            try
            {
                Thread.Sleep(2000);
                var elem = _driver.FindElement(By.XPath(xPath)).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element not Displayed!");
                Thread.Sleep(1000);
            }
            return _driver.FindElement(By.XPath(xPath)).Displayed;
        }
        protected void NavigateBack()
        {
            _driver.Navigate().Back();
        }
        protected bool IsCheckTitleExist(string textInTitle)
        {
            return _driver.Title.ToString().Contains(textInTitle);
        }
    }
}
