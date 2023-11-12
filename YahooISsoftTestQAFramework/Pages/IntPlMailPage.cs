using OpenQA.Selenium;
using IntISsoftTestQAFramework.Pages;
using OpenQA.Selenium.Support.UI;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace IntISsoftTestQAFramework
{
    public class IntPlMailPage : IntPlBasePage
    {
        const string MAIL_AVATAR_BUTTON = "//div[@class='avatar avatar--large']";
        const string MAIL_LOGOUT_BUTTON = "//a[@class='account-info__logout button']";
        const string BUTTON_SEND_MESSEGE = "//button[@class='button']";
        const string LETTER_AREA = "/html";
        const string BUTTON_NEW_MESSEGE = "//div[@class='navigation__new']";
        const string THEME_PLACEHOLDER = "//*[@id='subject']";
        const string TO_WHOM_PLACEHOLDER = "//input[@aria-label='Do']";
        const string REPLY_BUTTON = "//span[@class='icon icon-reply'][1]";
        static string MAIL_PAGE = "https://poczta.int.pl/";

        IWebDriver _driver;
        WebDriverWait _wait;
        public IntPlMailPage(IWebDriver driver, string url) : base(driver, MAIL_PAGE)
        {
            _driver = driver;
        }
        public void Logout() 
        {
            _driver.FindElement(By.XPath(MAIL_AVATAR_BUTTON)).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MAIL_LOGOUT_BUTTON)));
            _driver.FindElement(By.XPath(MAIL_LOGOUT_BUTTON)).Click();
        }
        public void CreateLetter(User user) 
        {
            Actions actions = new Actions(_driver);
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BUTTON_NEW_MESSEGE)));
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath(BUTTON_NEW_MESSEGE)).Click();
            _driver.FindElement(By.XPath(TO_WHOM_PLACEHOLDER)).Click();
            var elemThemePlaceHolder = _driver.FindElement(By.XPath(THEME_PLACEHOLDER));
            _driver.FindElement(By.XPath(TO_WHOM_PLACEHOLDER)).SendKeys(user.MailAdress);
            var elemButtonSendMessege = _driver.FindElement(By.XPath(BUTTON_SEND_MESSEGE));
            var elemLetterArea = _driver.FindElement(By.XPath(LETTER_AREA));
            actions.MoveToElement(elemLetterArea)
                    .Click()
                    .MoveToElement(elemThemePlaceHolder)
                    .Click()
                    .SendKeys(user.ThemeLetter)
                    .MoveToElement(elemLetterArea)
                    .Click()
                    .SendKeys(user.TextLetter)
                    .MoveToElement(elemButtonSendMessege)
                    .Click()
                    .Build()
                    .Perform();
        }
        /// <summary>
        /// The method returns 'true' if the message from the user was received.
        /// </summary>
        /// <param name="user">The user from whom we receive the letter.</param>
        /// <returns></returns>
        public bool CheckLetter(User user)
        {
            string letterFromUserXPath = $"//span[@title='{user.MailAdress}'][1]";
            var elemlastLetterFromSecondUser = _driver.FindElement(By.XPath(letterFromUserXPath));
            bool isLetterFromFromSecondUser = elemlastLetterFromSecondUser.Displayed;
            var elemletterWhisWriteTheme = _driver.FindElement(By.XPath(letterFromUserXPath));
            bool isThemeCorrect = elemletterWhisWriteTheme.Displayed;
            return isLetterFromFromSecondUser && isThemeCorrect;
        }
        /// <summary>
        /// The user replies to the letter and sends a message.
        /// </summary>
        /// <param name="user"></param>
        public void ReplyLetter(User user)
        {            
            Actions actions = new Actions(_driver);
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath(REPLY_BUTTON)).Click();
            _driver.FindElement(By.XPath(REPLY_BUTTON)).Click();
            var elemLetterArea = _driver.FindElement(By.XPath(LETTER_AREA));
            var elemButtonSendMessege = _driver.FindElement(By.XPath(BUTTON_SEND_MESSEGE));
            actions.MoveToElement(elemLetterArea)
                    .Click()
                    .SendKeys(user.ThemeTextReplyLetter)
                    .MoveToElement(elemButtonSendMessege)
                    .Click()
                    .Build()
                    .Perform();
        }
        /// <summary>
        /// The method returns 'true' if it finds a letter from the user and the subject text of the letter is correct.
        /// </summary>
        /// <param name="user">The user from whom we receive the letter.</param>
        /// <returns></returns>
        public bool CheckReplyLetter(User user)
        {
            string letterFromUserXPath = $"//span[@title='{user.MailAdress}'][1]";
            var elemlastLetterFromFirstUser = _driver.FindElement(By.XPath(letterFromUserXPath));
            bool isLetterFromFromFirstUser = elemlastLetterFromFirstUser.Displayed;
            var elemletterWhisWriteTheme = _driver.FindElement(By.XPath(user.ThemeTextReplyLetter));
            bool isThemeCorrect = elemletterWhisWriteTheme.Displayed;
            return isLetterFromFromFirstUser && isThemeCorrect;
        }
    }
}
