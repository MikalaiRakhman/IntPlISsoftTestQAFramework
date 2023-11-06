using OpenQA.Selenium;
using IntISsoftTestQAFramework.Pages;

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
        
        public IntPlMailPage(IWebDriver webDriver) : base(webDriver, MAIL_PAGE)
        {
            
        }

        public string GetMailAvatarButton()
        {
            return MAIL_AVATAR_BUTTON;
        }

        public string GetMailLogoutButton()
        {
            return MAIL_LOGOUT_BUTTON;
        }
        public string GetButtonSendMessege()
        {
            return BUTTON_SEND_MESSEGE;
        }
        public string GetLetterArea() 
        {
            return LETTER_AREA;
        }
        public string GetButtonNewMessege()
        {
            return BUTTON_NEW_MESSEGE;
        }
        public string GetThemePlaceHolder() 
        {
            return THEME_PLACEHOLDER;
        }
        public string GetToWhomPlaceHolder()
        {
            return TO_WHOM_PLACEHOLDER;
        }
        public string GetReplyButton() 
        {
            return REPLY_BUTTON;
        }
        
    }
}
