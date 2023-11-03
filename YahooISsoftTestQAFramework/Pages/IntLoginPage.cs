using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace IntISsoftTestQAFramework.Pages
{
    internal class IntLoginPage : IntPlBasePage
    {

        public IntLoginPage(IWebDriver webDriver) : base(webDriver, LOGIN_PAGE)
        {

        }

    }
}
