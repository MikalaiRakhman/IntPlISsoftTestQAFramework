using OpenQA.Selenium;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace IntISsoftTestQAFramework.Pages
{
    public class IntPlMainPage : IntPlBasePage
    {
        const string MAIN_INPUT_MAIL_PLACEHOLDER = "//*[@id='emailId']";
        const string MAIN_LOGIN_BUTTON = "//button[@class='button button--left button--smaller button--mark button--moema']";
        const string MAIN_INPUT_PASSWORD_PLACEHOLDER = "//*[@id='passwordId']";
        static string MAIN_PAGE = "https://int.pl/";
        IWebDriver _driver;     
        public IntPlMainPage(IWebDriver driver, string url) : base (driver, MAIN_PAGE)  
        {
            _driver = driver;
        }
        public void login (User user) 
        {
            Actions actions = new Actions(_driver);
            var mailPlaceHolder = _driver.FindElement(By.XPath(MAIN_INPUT_MAIL_PLACEHOLDER));
            var passwordPlaceHolder = _driver.FindElement(By.XPath(MAIN_INPUT_PASSWORD_PLACEHOLDER));
            var loginButton = _driver.FindElement(By.XPath(MAIN_LOGIN_BUTTON));
            actions.MoveToElement(mailPlaceHolder)
            .Click()
                .SendKeys(user.MailAdress)
                .MoveToElement(passwordPlaceHolder)
            .Click()
                .SendKeys(user.Password)
                .MoveToElement(loginButton)
                .Click()
                .Build()
                .Perform();
        }        
    }
}
