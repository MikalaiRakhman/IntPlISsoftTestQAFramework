using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace YahooISsoftTestQAFramework
{
    internal class YahooLoginPage : YahooBasePage
    {
        public YahooLoginPage(IWebDriver webDriver, WebDriverWait wait) : base(webDriver, LOGIN_PAGE) 
        {

        }
        
    }
}
