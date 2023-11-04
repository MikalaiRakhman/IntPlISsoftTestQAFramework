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
        const string MAIL_AVATAR_BUTTON = "//div[@class='avatar__content avatar__content--skin-3']";
        const string MAIL_LOGOUT_BUTTON = "//a[@class='account-info__logout button']";
        public IntPlMailPage(IWebDriver webDriver) : base(webDriver, MAIL_PAGE)
        {

        }

        public string GetMailAvatarButton()
        {
            return MAIL_AVATAR_BUTTON;
        }

        public string GetMailLogoutButton()
        {
            return MAIL_LOGOUT_BUTTON;
        }
    }
}
