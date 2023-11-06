using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using IntISsoftTestQAFramework.Users;
using IntISsoftTestQAFramework.Pages;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace IntISsoftTestQAFramework
{
    public class SecondUserIntPl : UsersIntPl
    {
        string _firstName { get; }
        string _lastName { get; }
        string _mailAdress { get; }
        string _password { get; }
        string _phoneNumber { get; }

        string _themeSecondUser;
        string _letterFromSecondUser;
        string _lastLetterFromFirstUser;
        string _letterThemeFromFirstUser;
        string answerFromFirstUserXPath = "//span[text()='Re: LETTER FROM SECOND USER']";
        public SecondUserIntPl(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _firstName = "Pavel";
            _lastName = "Morozov";
            _mailAdress = "pavelmorozov302@int.pl";
            _password = "x%Y%c78@/n!T.bx";
            _phoneNumber = "572057407";
            _themeSecondUser = "LETTER FROM SECOND USER";
            _letterFromSecondUser = "Hello Pupkin!!!";
            _lastLetterFromFirstUser = "//span[@title='vasiapupkin359@int.pl'][1]";
            _letterThemeFromFirstUser = "//span[text()='LETTER FROM FIRST USER']";

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
            SecondUserIntPl second = new SecondUserIntPl(driver, wait);
            driver.FindElement(By.XPath(mainPage.GetInputMailPLaceHolder())).SendKeys(second.GetMailAdress());
            driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).Click();
            driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).SendKeys(second.GetPassword());
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
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            Actions actions = new Actions(driver);
            IntPlMailPage mailPage = new IntPlMailPage(driver);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BUTTON_NEW_MESSEGE)));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(BUTTON_NEW_MESSEGE)).Click();
            driver.FindElement(By.XPath(TO_PLACEHOLDER)).Click();
            var elemThemePlaceHolder = driver.FindElement(By.XPath(THEME_PLACEHOLDER));

            driver.FindElement(By.XPath(TO_PLACEHOLDER)).SendKeys(first.GetMailAdress());

            var elemButtonSendMessege = driver.FindElement(By.XPath(mailPage.GetButtonSendMessege()));
            var elemLetterArea = driver.FindElement(By.XPath(LETTER_AREA));

            actions.MoveToElement(elemLetterArea)
                    .Click()
                    .MoveToElement(elemThemePlaceHolder)
                    .Click()
                    .SendKeys(_themeSecondUser)
                    .MoveToElement(elemLetterArea)
                    .Click()
                    .SendKeys(_letterFromSecondUser)
                    .MoveToElement(elemButtonSendMessege)
                    .Click()
                    .Build()
                    .Perform();
        }

        public override bool CheckLetter()
        {
            var elemlastLetterFromFirstUser = driver.FindElement(By.XPath(_lastLetterFromFirstUser));
            bool isLetterFromFromFirstUser = elemlastLetterFromFirstUser.Displayed;
            var elemletterWhisWriteTheme = driver.FindElement(By.XPath(_letterThemeFromFirstUser));
            bool isThemeCorrect = elemletterWhisWriteTheme.Displayed;
            return isLetterFromFromFirstUser && isThemeCorrect;
        }

        public override void ReplyLetter()
        {
            Actions actions = new Actions(driver);
            driver.FindElement(By.XPath(REPLY)).Click();
            driver.FindElement(By.XPath(LETTER_AREA)).Click();
            var elemLetterArea = driver.FindElement(By.XPath("/html"));
            var elemButtonSendMessege = driver.FindElement(By.XPath("//button[@class='button']"));
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
            var elemlastLetterFromFirstUser = driver.FindElement(By.XPath(_lastLetterFromFirstUser));
            bool isLetterFromFromFirstUser = elemlastLetterFromFirstUser.Displayed;
            var elemletterWhisWriteTheme = driver.FindElement(By.XPath(answerFromFirstUserXPath));
            bool isThemeCorrect = elemletterWhisWriteTheme.Displayed;
            return isLetterFromFromFirstUser && isThemeCorrect;
        }
    }
}
