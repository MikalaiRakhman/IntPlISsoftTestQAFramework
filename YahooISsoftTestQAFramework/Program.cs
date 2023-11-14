using IntISsoftTestQAFramework.Users;
using IntISsoftTestQAFramework.Pages;
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
            IWebDriver driver = new ChromeDriver();
            MailPage mailPage = new MailPage(driver);
            MainPage mainPage = new MainPage(driver);            
            User first = new User("vasiapupkin359@int.pl", "779TjRse+nHLw$v", "from first user", "hello second user!", "This is reply text from 'first' user");
            User second = new User("pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "from second user", "hello first user!", "This is reply text from 'second' user");
            mainPage.login(first);
            Thread.Sleep(2000);
            mailPage.NewMessege();
            mailPage.CreateLetter(first, second, first.TextLetter);
            mailPage.SendLetter();
            Thread.Sleep(2000);
            mailPage.Logout();            
            Thread.Sleep(1000);
            mainPage.login(second);
            Thread.Sleep(2000);
            var result = mailPage.CheckLetterFrom(first, first.TextLetter);
            mailPage.OpenReplyLetter();            
            mailPage.CreateLetter(second, first, second.TextReplyLetter);
            mailPage.SendLetter();
            Thread.Sleep(5000);
            mailPage.Logout();            
            Thread.Sleep(1000);
            mainPage.login(first);
            Thread.Sleep(5000);
            var result2 = mailPage.CheckLetterFrom(second, second.TextReplyLetter);
            mailPage.Logout();
            driver.Close();            
        }
    }
}