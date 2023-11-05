using IntISsoftTestQAFramework.Pages;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace IntISsoftTestQAFramework
{
    internal class FirstUserIntPl : UsersIntPl
    {
        string _firstName {  get;  }
        string _lastName {  get; }
        string _mailAdress {  get; }
        string _password { get; }
        string _phoneNumber { get; }

        string _themeFirstUser;
        string _letterFromFirstUser; 


        public FirstUserIntPl(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {

            _firstName = "Vasia";
            _lastName = "Pupkin";
            _mailAdress = "vasiapupkin359@int.pl";
            _password = "779TjRse+nHLw$v";
            _phoneNumber = "572068230";
            _themeFirstUser = "LETTER FROM FIRST USER";
            _letterFromFirstUser = "Hello Morozov!!!";
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
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IntPlMainPage mainPage = new IntPlMainPage(driver);
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            driver.FindElement(By.XPath(mainPage.GetInputMailPLaceHolder())).SendKeys(first.GetMailAdress());
            driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).Click();
            driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).SendKeys(first.GetPassword());
            driver.FindElement(By.XPath(mainPage.GetLoginButton())).Click();

        }

        public override void Logout()
        {
            IntPlMailPage mailPage = new IntPlMailPage(driver);
            driver.FindElement(By.XPath(mailPage.GetMailAvatarButton())).Click();
            driver.FindElement(By.XPath(mailPage.GetMailLogoutButton())).Click();
           
        }

        public override void CreateLetter()
        {
            SecondUserIntPl second = new SecondUserIntPl(driver, wait);
            Actions actions = new Actions(driver);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BUTTON_NEW_MESSEGE)));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(BUTTON_NEW_MESSEGE)).Click();
            
            driver.FindElement(By.XPath(TO_PLACEHOLDER)).Click();
            var elemThemePlaceHolder = driver.FindElement(By.XPath(THEME_PLACEHOLDER));
            
            driver.FindElement(By.XPath(TO_PLACEHOLDER)).SendKeys(second.GetMailAdress());
            
            var elemButtonSendMessege = driver.FindElement(By.XPath(BUTTON_SEND_MESSEGE));
            var elemLetterArea = driver.FindElement(By.XPath(LETTER_AREA));

            actions.MoveToElement(elemLetterArea)  
                    .Click()
                    .MoveToElement(elemThemePlaceHolder)
                    .Click()
                    .SendKeys(_themeFirstUser)
                    .MoveToElement(elemLetterArea)
                    .Click()
                    .SendKeys(_letterFromFirstUser)
                    .MoveToElement(elemButtonSendMessege)
                    .Click()
                    .Build()
                    .Perform();

            
        }
    }
}
