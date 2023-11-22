using IntISsoftTestQAFramework.Pages;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace IntISsoftTestQAFramework
{/// <summary>
/// A method to help develop a program. Here I process different program scenarios.
/// </summary>
    public class Program
    {    
        static void Main(string[] args)
        {
            User first = new User("vasiapupkin359@int.pl", "779TjRse+nHLw$v", "hello second user!", "reply for your messege 'second'");
            User second = new User("pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "hello first user!", "reply for your messege 'first'");
            IWebDriver driver = new ChromeDriver();            
            MailPage mailPage = new MailPage(driver);
            MainPage mainPage = new MainPage(driver);
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