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
        const string IFRAME = "//iframe[1]";
        const string MAIL_PAGE = "https://poczta.int.pl/";
        
        public MailPage(IWebDriver driver, WebDriverWait wait, Actions actions) : base(driver, wait, actions, MAIL_PAGE)
        {
            
        }
        public string GetAvatarButton()
        {
            return AVATAR_BUTTON;
        }
        public void Logout() 
        {
            RefreshPage();
            /*_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            _driver.FindElement(By.XPath(AVATAR_BUTTON)).Click();
            */
            ClickOnElementByClassName(AVATAR_BUTTON);
            /*
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MAIL_LOGOUT_BUTTON)));
            _driver.FindElement(By.XPath(MAIL_LOGOUT_BUTTON)).Click();
            */
            ClickOnElementByClassName(MAIL_LOGOUT_BUTTON);
        }
        /// <summary>
        /// The method that enters the subject of the letter, to whom the letter is written, enters the mail.
        /// </summary>
        /// <param name="fromUser"></param>
        /// <param name="toUser"></param>
        /// <param name="textLetter"></param>
        public void CreateLetter(User fromUser, User toUser, string textLetter) 
        {
            /* Actions actions = new Actions(_driver);
             var elemToWhomPlaceholder = _driver.FindElement(By.XPath(TO_WHOM_PLACEHOLDER));
             var elemThemePlaceHolder = _driver.FindElement(By.XPath(THEME_PLACEHOLDER));
             var elemLetterArea = _driver.FindElement(By.XPath(LETTER_AREA));
             actions.MoveToElement(elemToWhomPlaceholder)
                 .Click()                
                 .SendKeys(toUser.MailAdress)                
                 .MoveToElement(elemLetterArea)
                 .Click()                
                 .SendKeys(textLetter)                 
                 .MoveToElement(elemThemePlaceHolder)
                 .Click()                
                 .SendKeys(fromUser.ThemeLetter)
                 .Build()
                 .Perform();
            */
            ClickOnElementByClassName(TO_WHOM_PLACEHOLDER);
            SendKeys(toUser.MailAdress);
            ClickOnElementByClassName(LETTER_AREA);
            SendKeys(textLetter);
            ClickOnElementByClassName(THEME_PLACEHOLDER);
            SendKeys(fromUser.ThemeLetter);

        }
        /// <summary>
        /// The method returns 'true' if the message from the user was received. The method checks the correctness of the email and the text of the letter.
        /// </summary>
        /// <param name="user">The user from whom we receive the letter.</param>
        /// <param name="textToCheck">The text we need to check.</param>
        /// <returns></returns>
        public bool CheckLetterFrom(User user, string textToCheck)
        {
            /*
            string letterFromUserXPath = $"//span[@title='{user.MailAdress}'][1]";
            var elemlastLetterFromFirstUser = _driver.FindElement(By.XPath(letterFromUserXPath));
            bool isLetterFromFromFirstUser = elemlastLetterFromFirstUser.Displayed;
            bool isContainsTextLetter = FindTheTextInTheFrame(textToCheck, IFRAME);
            return isLetterFromFromFirstUser && isContainsTextLetter;
            */
            return IsElementDisplayed($"//span[@title='{user.MailAdress}'][1]") && FindTheTextInTheFrame(textToCheck, IFRAME);
        }

        
        public void SendLetter()
        {
            /*Actions actions = new Actions(_driver);
            var elemButtonSendMessege = _driver.FindElement(By.XPath(BUTTON_SEND_MESSEGE));
            actions.MoveToElement(elemButtonSendMessege)
                   .Click()
                   .Build()
                   .Perform();
            */
            ClickOnElementByClassName(BUTTON_SEND_MESSEGE);
        }
        public void NewMessege() 
        {
            /*Actions actions = new Actions(_driver);            
            actions.MoveToElement(Element(BUTTON_NEW_MESSEGE))
                .Click()
                .Build()
                .Perform();
            */
            ClickOnElementByClassName(BUTTON_NEW_MESSEGE);
        }
        public void OpenReplyLetter() 
        {
            RefreshPage();
            Thread.Sleep(2000);
            ClickOnElementByClassName(REPLY_BUTTON);
        }
    }
}
