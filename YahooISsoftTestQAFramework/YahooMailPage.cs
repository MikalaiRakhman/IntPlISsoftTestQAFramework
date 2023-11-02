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
    internal class YahooMailPage : YahooBasePage
    {
        public YahooMailPage(IWebDriver webDriver, WebDriverWait wait) : base(webDriver, MAIL_PAGE)
        {

        }
    }
}
