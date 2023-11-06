using OpenQA.Selenium;
using IntISsoftTestQAFramework.Pages;

namespace IntISsoftTestQAFramework
{
    public class IntPlMailPage : IntPlBasePage
    {
        const string MAIL_AVATAR_BUTTON = "//div[@class='avatar avatar--large']";
        const string MAIL_LOGOUT_BUTTON = "//a[@class='account-info__logout button']";
        const string BUTTON_SEND_MESSEGE = "//button[@class='button']";
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

    }
}
