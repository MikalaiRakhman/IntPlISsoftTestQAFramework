using OpenQA.Selenium;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium.Interactions;
namespace IntISsoftTestQAFramework.Pages
{
    public class MainPage : BasePage
    {
        const string INPUT_MAIL_PLACEHOLDER = "//*[@id='emailId']";
        const string LOGIN_BUTTON = "//button[@class='button button--left button--smaller button--mark button--moema']";
        const string INPUT_PASSWORD_PLACEHOLDER = "//*[@id='passwordId']";
        const string CLOSE_POPUP_CLASS_NAME = "popup__close-btn";
        static string MAIN_PAGE = "https://int.pl/";
        IWebDriver _driver;     
        public MainPage(IWebDriver driver) : base (driver, MAIN_PAGE)  
        {
            _driver = driver;
        }
        public void login(User user)
        {
            try
            {
                ClosePopup();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Popup not found.");
            }
            finally
            {
                RefreshPage();
                Actions actions = new Actions(_driver);
                var mailPlaceHolder = _driver.FindElement(By.XPath(INPUT_MAIL_PLACEHOLDER));
                var passwordPlaceHolder = _driver.FindElement(By.XPath(INPUT_PASSWORD_PLACEHOLDER));
                var loginButton = _driver.FindElement(By.XPath(LOGIN_BUTTON));
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
        public string GetLoginButton()
        {
            return LOGIN_BUTTON;
        }
        public string GetInputMailPLaceHolder()
        {
            return INPUT_MAIL_PLACEHOLDER;
        }
        public string GetInputPasswordPLaceHolder() 
        {
            return INPUT_PASSWORD_PLACEHOLDER;
        }
        public void ClosePopup()
        {
            _driver.FindElement(By.ClassName(CLOSE_POPUP_CLASS_NAME)).Click();
        }
    }
}
