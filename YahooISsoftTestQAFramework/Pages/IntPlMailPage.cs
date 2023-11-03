using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using IntISsoftTestQAFramework.Pages;

namespace IntISsoftTestQAFramework
{
    internal class IntPlMailPage : IntPlBasePage
    {
        public IntPlMailPage(IWebDriver webDriver) : base(webDriver, MAIL_PAGE)
        {

        }
    }
}
