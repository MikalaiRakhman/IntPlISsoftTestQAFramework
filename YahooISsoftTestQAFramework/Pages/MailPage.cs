using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace IntISsoftTestQAFramework.Pages
{
    public class MailPage : BasePage
    {
        const string AVATAR_BUTTON = "//div[@class='avatar avatar--large']";
        const string MAIL_LOGOUT_BUTTON = "//a[@class='account-info__logout button']";
        const string BUTTON_SEND_MESSEGE = "//button[@class='button']";
        const string LETTER_AREA = "/html";
        const string BUTTON_NEW_MESSEGE = "//div[@class='navigation__new']";
        const string THEME_PLACEHOLDER = "//*[@id='subject']";
        const string TO_WHOM_PLACEHOLDER = "//input[@aria-label='Do']";
        const string REPLY_BUTTON = "//span[@class='icon icon-reply'][1]";
        // $$("[data-tooltip='Odpowiedz']")
        const string IFRAME = "//iframe[1]";
        const string MAIL_PAGE = "https://poczta.int.pl/";

        IWebDriver _driver;
        WebDriverWait _wait;
        public MailPage(IWebDriver driver) : base(driver, MAIL_PAGE)
        {
            _driver = driver;
        }
        public void Logout() 
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _driver.FindElement(By.XPath(AVATAR_BUTTON)).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MAIL_LOGOUT_BUTTON)));
            _driver.FindElement(By.XPath(MAIL_LOGOUT_BUTTON)).Click();
        }
        public void CreateLetterAndSend(User fromUser, User toUser) 
        {
            Actions actions = new Actions(_driver);
            Thread.Sleep(2000);
            var elemButtonNewMessege = _driver.FindElement(By.XPath(BUTTON_NEW_MESSEGE));
            actions.MoveToElement(elemButtonNewMessege)
                .Click()
                .Build()
                .Perform();
            Thread.Sleep(1000);
            var elemToWhomPlaceholder = _driver.FindElement(By.XPath(TO_WHOM_PLACEHOLDER));
            var elemThemePlaceHolder = _driver.FindElement(By.XPath(THEME_PLACEHOLDER));
            var elemLetterArea = _driver.FindElement(By.XPath(LETTER_AREA));
            var elemButtonSendMessege = _driver.FindElement(By.XPath(BUTTON_SEND_MESSEGE));
            actions.MoveToElement(elemToWhomPlaceholder)
                .Click()
                .SendKeys(toUser.MailAdress)                
                .MoveToElement(elemLetterArea)
                .Click()
                .SendKeys(fromUser.TextLetter)                 
                .MoveToElement(elemThemePlaceHolder)
                .Click()
                .SendKeys(fromUser.ThemeLetter)
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
        public bool CheckLetterFrom(User user)
        {
            string letterFromUserXPath = $"//span[@title='{user.MailAdress}'][1]";
            var elemlastLetterFromFirstUser = _driver.FindElement(By.XPath(letterFromUserXPath));
            bool isLetterFromFromFirstUser = elemlastLetterFromFirstUser.Displayed;
            bool isContainsText = FindTheTextInTheFrame(user.TextLetter, IFRAME);
            return isLetterFromFromFirstUser && isContainsText;
            /*
            string letterFromUserXPath = $"//span[@title='{user.MailAdress}'][1]";
            var elemlastLetterFromSecondUser = _driver.FindElement(By.XPath(letterFromUserXPath));
            bool isLetterFromFromSecondUser = elemlastLetterFromSecondUser.Displayed;
            var elemletterWhisWriteTheme = _driver.FindElement(By.XPath(letterFromUserXPath));
            bool isThemeCorrect = elemletterWhisWriteTheme.Displayed;
            return isLetterFromFromSecondUser && isThemeCorrect;
            */
        }
        /// <summary>
        /// The user replies to the letter and sends a message.
        /// </summary>
        /// <param name="user">The user who is currently replying to the email.</param>
        public void ReplyLetterFrom(User user)
        {
            Actions actions = new Actions(_driver);
            Thread.Sleep(1000);
            var elemButtonReply = _driver.FindElement(By.CssSelector(".icon-reply"));
            var elemLetterArea = _driver.FindElement(By.XPath(LETTER_AREA));
            var elemButtonSendMessege = _driver.FindElement(By.XPath(BUTTON_SEND_MESSEGE));
            actions.MoveToElement(elemButtonReply)
                    .Click()
                    .Pause(TimeSpan.FromSeconds(1))
                    .SendKeys(user.TextReplyLetter)
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
        public bool CheckReplyLetterFrom(User user)
        {
            string letterFromUserXPath = $"//span[@title='{user.MailAdress}'][1]";
            var elemlastLetterFromFirstUser = _driver.FindElement(By.XPath(letterFromUserXPath));
            bool isLetterFromFromFirstUser = elemlastLetterFromFirstUser.Displayed;
            bool isContainsText = FindTheTextInTheFrame(user.TextReplyLetter, IFRAME);
            return isLetterFromFromFirstUser && isContainsText;
        }
        public string GetAvatarButton()
        {
            return AVATAR_BUTTON;
        }
        public bool FindTheTextInTheFrame(string text, string xPath)
        {
            var frame = _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(xPath)));
            return frame.PageSource.ToString().Contains(text);
        }
    }
}
