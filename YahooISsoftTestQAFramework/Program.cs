using IntISsoftTestQAFramework.Users;
using IntISsoftTestQAFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace IntISsoftTestQAFramework
{
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
            mailPage.CreateLetterAndSend(first, second);
            Thread.Sleep(2000);
            mailPage.Logout();
            Thread.Sleep(15000);
            mainPage.login(second);
            Thread.Sleep(2000);
            var result = mailPage.CheckLetterFrom(first);
            Thread.Sleep(5000);
            mailPage.ReplyLetter(second);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(15000);
            mainPage.login(first);
            Thread.Sleep(5000);
            var result2 = mailPage.CheckReplyLetterFrom(second);        
     
            driver.Close();            
        }
    }
}