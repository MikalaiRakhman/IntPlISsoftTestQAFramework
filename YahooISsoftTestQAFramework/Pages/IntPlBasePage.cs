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

        public void NavigateBack()
        {
            _webDriver.Navigate().Back();
        }






    }
}
