﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace IntISsoftTestQAFramework.Pages
{
    internal class IntPlMainPage : IntPlBasePage
    {
        public const string MAIN_INPUT_MAIL_PLACEHOLDER = "//*[@id='emailId']";
        public const string MAIN_LOGIN_BUTTON = "//button[@class='button button--left button--smaller button--mark button--moema']";
        public const string MAIN_INPUT_PASSWORD_PLACEHOLDER = "//*[@id='passwordId']";
        public IntPlMainPage(IWebDriver webDriver) : base(webDriver, MAIN_PAGE)
        {

        }

        public string GetInputMailPLaceHolder()
        {
            return MAIN_INPUT_MAIL_PLACEHOLDER;
        }

        public string GetLoginButton()
        {
            return MAIN_LOGIN_BUTTON;
        }

        public string GetInputPasswordPLaceHolder()
        {
            return MAIN_INPUT_PASSWORD_PLACEHOLDER;
        }

    }
}
