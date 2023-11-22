using OpenQA.Selenium;
using System.Threading;
namespace IntPlLibrary.PagesL
{
    public class MailPage : BasePage
    {
        const string AVATAR_BUTTON = "//div[@class='avatar avatar--large']";
        const string MAIL_LOGOUT_BUTTON = "//a[@class='account-info__logout button']";
        const string BUTTON_SEND_MESSEGE = "//button[@class='button']";
        const string LETTER_AREA = "/html";
        const string BUTTON_NEW_MESSEGE = "//div[@class='navigation__new']";
        const string TO_WHOM_PLACEHOLDER = "//input[@aria-label='Do']";
        const string REPLY_BUTTON = "//span[@class='icon icon-reply'][1]";
        const string IFRAME = "//iframe[1]";
        const string MAIL_PAGE = "https://poczta.int.pl/";
        public MailPage(IWebDriver driver) : base(driver, MAIL_PAGE)
        {

        }
        public string GetAvatarButton()
        {
            return AVATAR_BUTTON;
        }
        public void Logout()
        {
            RefreshPage();
            ClickOnElementByXPath(AVATAR_BUTTON);
            ClickOnElementByXPath(MAIL_LOGOUT_BUTTON);
            Thread.Sleep(1000);
        }
        /// <summary>
        /// The method that enters the mail and to whom the letter is written.
        /// </summary>
        /// <param name="fromUser"></param>
        /// <param name="toUser"></param>
        /// <param name="textLetter"></param>
        public void CreateLetter(User fromUser, User toUser, string textLetter)
        {
            ClickOnElementByXPath(TO_WHOM_PLACEHOLDER);
            SendKeys(toUser.MailAdress);
            Thread.Sleep(1000);
            ClickOnElementByXPath(LETTER_AREA);
            SendKeys(textLetter);
            Thread.Sleep(1000);
        }
        /// <summary>
        /// The method returns 'true' if the message from the user was received. The method checks the correctness of the email and the text of the letter.
        /// </summary>
        /// <param name="user">The user from whom we receive the letter.</param>
        /// <param name="textToCheck">The text we need to check.</param>
        /// <returns></returns>
        public bool CheckLetterFrom(User user, string textToCheck)
        {
            return IsElementDisplayed($"//span[@title='{user.MailAdress}'][1]") && FindTheTextInTheFrame(textToCheck, IFRAME);
        }
        public void SendLetter()
        {
            ClickOnElementByXPath(BUTTON_SEND_MESSEGE);
            Thread.Sleep(2000);
        }
        public void NewMessege()
        {
            ClickOnElementByXPath(BUTTON_NEW_MESSEGE);
        }
        public void OpenReplyLetter()
        {
            RefreshPage();
            Thread.Sleep(2000);
            ClickOnElementByXPath(REPLY_BUTTON);
        }
        public bool IsAvatarButtonEnabled()
        {
            return Element(AVATAR_BUTTON).Enabled;
        }
    }
}