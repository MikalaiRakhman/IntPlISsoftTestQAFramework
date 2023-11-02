using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace YahooISsoftTestQAFramework
{
    internal abstract class YahooBasePage
    {
        public const string MAIN_PAGE = "https://www.yahoo.com/";
        public const string MAIL_PAGE = "https://mail.yahoo.com/";
        public const string LOGIN_PAGE = "https://login.yahoo.com/";
        public const string ACCEPT_COOKIES_XPATH = "//button[@class='btn secondary accept-all ']";

        IWebDriver _webDriver;
        WebDriverWait _wait;

        public YahooBasePage(IWebDriver webDriver, string url) 
        {
            _webDriver = webDriver;
            _webDriver.Url = url;
            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            _webDriver.Manage().Window.Maximize();
            
        }

        public void NavigateBack()
        {
            _webDriver.Navigate().Back();
        }

        public void AcceptCookies()
        {
            _webDriver.FindElement(By.XPath(ACCEPT_COOKIES_XPATH)).Click();
        }
        
        
    }
}
