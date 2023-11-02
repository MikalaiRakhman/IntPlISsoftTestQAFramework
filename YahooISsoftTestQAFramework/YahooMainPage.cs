using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace YahooISsoftTestQAFramework
{
    internal class YahooMainPage : YahooBasePage
    {
        
        public YahooMainPage(IWebDriver webDriver, WebDriverWait wait) : base(webDriver, MAIN_PAGE)
        {

        }

    }
}
