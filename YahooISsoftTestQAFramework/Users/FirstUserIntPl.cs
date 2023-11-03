using IntISsoftTestQAFramework.Pages;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntISsoftTestQAFramework
{
    internal class FirstUserIntPl : UsersIntPl
    {
        string _firstName {  get;  }
        string _lastName {  get; }
        string _mailAdress {  get; }
        string _password { get; }
        string _phoneNumber { get; }


        public FirstUserIntPl(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {

            _firstName = "Vasia";
            _lastName = "Pupkin";
            _mailAdress = "vasiapupkin359";
            _password = "779TjRse+nHLw$v";
            _phoneNumber = "572068230";
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

        public void LoginInAccount()
        {
           
        }

        public override void Login()
        {
            
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IntPlMainPage mainPage = new IntPlMainPage(_driver);
            FirstUserIntPl first = new FirstUserIntPl(_driver, _wait);
            _driver.FindElement(By.XPath(mainPage.GetInputMailPLaceHolder())).SendKeys(first.GetMailAdress());
            _driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).Click();
            _driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).SendKeys(first.GetPassword());
            _driver.FindElement(By.XPath(mainPage.GetLoginButton())).Click();

        }
    }
}
