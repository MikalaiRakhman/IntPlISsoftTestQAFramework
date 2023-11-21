using IntISsoftTestQAFramework.Pages;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
namespace IntISsoftTestQAFramework
{/// <summary>
/// A method to help develop a program. Here I process different program scenarios.
/// </summary>
    public class Program
    {    
        static void Main(string[] args)
        {
            User first = new User("vasiapupkin359@int.pl", "779TjRse+nHLw$v", "from first user", "hello second user!", "reply for your messege 'second'");
            User second = new User("pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "from second user", "hello first user!", "reply for your messege 'first'");
            IWebDriver driver = new ChromeDriver();
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MailPage mailPage = new MailPage(driver, wait, actions);
            MainPage mainPage = new MainPage(driver, wait, actions);
            mainPage.Login(first);            
            mailPage.NewMessege();
            mailPage.CreateLetter(first, second, first.TextLetter);
            mailPage.SendLetter();            
            mailPage.Logout();            
            mainPage.Login(second);            
            bool firstLetterArrivedAndCorrect = mailPage.CheckLetterFrom(first, first.TextLetter);
            mailPage.OpenReplyLetter();
            mailPage.CreateLetter(second, first, second.TextReplyLetter);
            mailPage.SendLetter();           
            mailPage.Logout();            
            mainPage.Login(first);            
            var replyLetterArrivedAndCorrect = mailPage.CheckLetterFrom(second, second.TextReplyLetter);
            mailPage.Logout();            
            driver.Close();
        }
    }
}