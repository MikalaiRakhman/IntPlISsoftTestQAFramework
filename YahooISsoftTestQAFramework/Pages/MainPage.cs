using OpenQA.Selenium;
using IntISsoftTestQAFramework.Users;
namespace IntISsoftTestQAFramework.Pages
{
    public class MainPage : BasePage
    {
        const string INPUT_MAIL_PLACEHOLDER = "//*[@id='emailId']";
        const string LOGIN_BUTTON = "//button[@class='button button--left button--smaller button--mark button--moema']";
        const string INPUT_PASSWORD_PLACEHOLDER = "//*[@id='passwordId']";
        const string CLOSE_POPUP_CLASS_NAME = "popup__close-btn";
        const string MAIN_PAGE_TITLE = "int.pl";
        static string MAIN_PAGE = "https://int.pl/";
        const string WRONG_PASSWORD = "**********";
        public MainPage(IWebDriver driver) : base (driver, MAIN_PAGE)  
        {
            
        }
        public void Login(User user)
        {
            RefreshPage();
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
                Thread.Sleep(2000);                
                if (!IsCheckTitleExist(MAIN_PAGE_TITLE))
                {
                    Thread.Sleep(1000);
                    NavigateBack();
                    Thread.Sleep(2000);
                }
                ClickOnElementByXPath(INPUT_MAIL_PLACEHOLDER);
                SendKeys(user.MailAdress);                
                ClickOnElementByXPath(INPUT_PASSWORD_PLACEHOLDER);
                SendKeys(WRONG_PASSWORD);
                ClickOnElementByXPath(LOGIN_BUTTON);
                Thread.Sleep(1000);
                ClickOnElementByXPath(INPUT_PASSWORD_PLACEHOLDER);
                SendKeys(user.Password);
                ClickOnElementByXPath(LOGIN_BUTTON);                
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
            ClickOnElementByClassName(CLOSE_POPUP_CLASS_NAME);
        }
        public bool IsLoginButtonEnabled()             
        {
            return Element(LOGIN_BUTTON).Enabled;
        }
        public bool IsInputMailPlaceholderEnabled() 
        {
            return Element(INPUT_MAIL_PLACEHOLDER).Enabled;
        }
        public bool IsInputPasswordPlaceholderEnabled()
        {
            return Element(INPUT_PASSWORD_PLACEHOLDER).Enabled;
        }
    }
}
