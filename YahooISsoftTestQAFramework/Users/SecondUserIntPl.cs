using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using IntISsoftTestQAFramework.Users;
using IntISsoftTestQAFramework.Pages;

namespace IntISsoftTestQAFramework
{
    internal class SecondUserIntPl : UsersIntPl
    {
        string _firstName { get; }
        string _lastName { get; }
        string _mailAdress { get; }
        string _password { get; }
        string _phoneNumber { get; }
        public SecondUserIntPl(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _firstName = "Pavel";
            _lastName = "Morozov";
            _mailAdress = "pavelmorozov302";
            _password = "x%Y%c78@/n!T.bx";
            _phoneNumber = "572057407";
        }

        public override string GetFirstName()
        {
            return _firstName;
        }

        public override string GetLastName()
        {
            return _lastName;
        }

        public override string GetMailAdress()
        {
            return _mailAdress;
        }

        public override string GetPassword()
        {
            return _password;
        }

        public override string GetPhoneNumber()
        {
            return _phoneNumber;
        }

        public override void Login()
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IntPlMainPage mainPage = new IntPlMainPage(_driver);
            SecondUserIntPl second = new SecondUserIntPl(_driver, _wait);
            _driver.FindElement(By.XPath(mainPage.GetInputMailPLaceHolder())).SendKeys(second.GetMailAdress());
            _driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).Click();
            _driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).SendKeys(second.GetPassword());
            _driver.FindElement(By.XPath(mainPage.GetLoginButton())).Click();
        }
    }
}
