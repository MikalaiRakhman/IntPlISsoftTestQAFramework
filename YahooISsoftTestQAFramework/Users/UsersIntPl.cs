using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IntISsoftTestQAFramework.Users
{
    public abstract class UsersIntPl
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public UsersIntPl(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public abstract string GetFirstName();
        public abstract string GetLastName();
        public abstract string GetMailAdress();
        public abstract string GetPassword();
        public abstract string GetPhoneNumber();
        public abstract void Login();
        public abstract void Logout();
        public abstract void CreateLetter();
        public abstract bool CheckLetter();
        public abstract void ReplyLetter();
        public abstract bool CheckReplyLetter();


    }
}
