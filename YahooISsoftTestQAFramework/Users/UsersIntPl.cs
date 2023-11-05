using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace IntISsoftTestQAFramework.Users
{
    public abstract class UsersIntPl
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        public const string TO_PLACEHOLDER = "//input[@aria-label='Do']";
        public const string THEME_PLACEHOLDER = "//*[@id='subject']";
        public const string LETTER_PLACEHOLDER = "//div[@class='mce-edit-area mce-container mce-panel mce-stack-layout-item mce-last']";
        public const string BUTTON_SEND_MESSEGE = "//button[@class='button']";
        public const string BUTTON_NEW_MESSEGE = "//div[@class='navigation__new']";
        public const string LETTER_AREA = "/html";



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


    }
}
