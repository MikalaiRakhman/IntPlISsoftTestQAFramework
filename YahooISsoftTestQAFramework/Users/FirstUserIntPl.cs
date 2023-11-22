using IntISsoftTestQAFramework.Pages;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace IntISsoftTestQAFramework
{
    public class FirstUserIntPl : UsersIntPl
    {
        string _firstName;
        string _lastName;
        string _mailAdress;
        string _password;
        string _phoneNumber;
        string _themeFirstUser;
        string _letterFromFirstUser;
        string _lastLetterFromSecondUser;
        string _letterThemeFromSecondUser;
        string answerFromSecondUserXPath = "//span[text()='Re: LETTER FROM FIRST USER']";
        public FirstUserIntPl(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _firstName = "Vasia";
            _lastName = "Pupkin";
            _mailAdress = "vasiapupkin359@int.pl";
            _password = "779TjRse+nHLw$v";
            _phoneNumber = "572068230";
            _themeFirstUser = "LETTER FROM FIRST USER";
            _letterFromFirstUser = "Hello Morozov!!!";
            _lastLetterFromSecondUser = "//span[@title='pavelmorozov302@int.pl'][1]";
            _letterThemeFromSecondUser = "//span[text()='LETTER FROM SECOND USER']";
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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IntPlMainPage mainPage = new IntPlMainPage(driver);
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            Actions actions = new Actions(driver);
            var mailPlaceHolder = driver.FindElement(By.XPath(mainPage.GetInputMailPLaceHolder()));
            var passwordPlaceHolder = driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder()));
            var loginButton = driver.FindElement(By.XPath(mainPage.GetLoginButton()));
            actions.MoveToElement(mailPlaceHolder)
                .Click()
                .SendKeys(first.GetMailAdress())
                .MoveToElement(passwordPlaceHolder)
                .Click()
                .SendKeys(first.GetPassword())
                .MoveToElement(loginButton)
                .Click()
                .Build()
                .Perform();
        }
        public override void Logout()
        {
            IntPlMailPage mailPage = new IntPlMailPage(driver);
            driver.FindElement(By.XPath(mailPage.GetMailAvatarButton())).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mailPage.GetMailLogoutButton())));
            driver.FindElement(By.XPath(mailPage.GetMailLogoutButton())).Click();
        }
        public override void CreateLetter()
        {
            SecondUserIntPl second = new SecondUserIntPl(driver, wait);
            Actions actions = new Actions(driver);
            IntPlMailPage mailPage = new IntPlMailPage(driver); 

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(mailPage.GetButtonNewMessege())));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(mailPage.GetButtonNewMessege())).Click();            
            driver.FindElement(By.XPath(mailPage.GetToWhomPlaceHolder())).Click();
            var elemThemePlaceHolder = driver.FindElement(By.XPath(mailPage.GetThemePlaceHolder()));
            driver.FindElement(By.XPath(mailPage.GetToWhomPlaceHolder())).SendKeys(second.GetMailAdress());
            var elemButtonSendMessege = driver.FindElement(By.XPath(mailPage.GetButtonSendMessege()));
            var elemLetterArea = driver.FindElement(By.XPath(mailPage.GetLetterArea()));

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
        public override bool CheckLetter()
        {
            var elemlastLetterFromSecondUser = driver.FindElement(By.XPath(_lastLetterFromSecondUser));
            bool isLetterFromFromSecondUser = elemlastLetterFromSecondUser.Displayed;
            var elemletterWhisWriteTheme = driver.FindElement(By.XPath(_letterThemeFromSecondUser));
            bool isThemeCorrect = elemletterWhisWriteTheme.Displayed;
            return isLetterFromFromSecondUser && isThemeCorrect;
        }
        public override void ReplyLetter()
        {
            IntPlMailPage malePage = new IntPlMailPage(driver);
            Actions actions = new Actions(driver);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(malePage.GetReplyButton())).Click();
            driver.FindElement(By.XPath(malePage.GetReplyButton())).Click();
            var elemLetterArea = driver.FindElement(By.XPath(malePage.GetLetterArea()));
            var elemButtonSendMessege = driver.FindElement(By.XPath(malePage.GetButtonSendMessege()));
            actions.MoveToElement(elemLetterArea)
                    .Click()
                    .SendKeys("LETTER REPLY")
                    .MoveToElement(elemButtonSendMessege)
                    .Click()
                    .Build()
                    .Perform();
        }
        public override bool CheckReplyLetter()
        {
            var elemlastLetterFromFirstUser = driver.FindElement(By.XPath(_lastLetterFromSecondUser));
            bool isLetterFromFromFirstUser = elemlastLetterFromFirstUser.Displayed;
            var elemletterWhisWriteTheme = driver.FindElement(By.XPath(answerFromSecondUserXPath));
            bool isThemeCorrect = elemletterWhisWriteTheme.Displayed;
            return isLetterFromFromFirstUser && isThemeCorrect;
        }
    }
}
