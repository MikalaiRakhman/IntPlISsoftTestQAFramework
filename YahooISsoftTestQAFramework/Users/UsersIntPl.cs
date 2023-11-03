using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace IntISsoftTestQAFramework.Users
{
    public abstract class UsersIntPl
    {
        public IWebDriver _driver;
        public WebDriverWait _wait;




        public UsersIntPl(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;

        }

        public abstract string GetFirstName();


        public abstract string GetLastName();


        public abstract string GetMailAdress();


        public abstract string GetPassword();


        public abstract string GetPhoneNumber();

        public abstract void Login();


    }
}
