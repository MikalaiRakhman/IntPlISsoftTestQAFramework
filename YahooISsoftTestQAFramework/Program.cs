using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace IntISsoftTestQAFramework
{
    public class Program
    {    
        static void Main(string[] args)
        {           
            IWebDriver driver = new ChromeDriver();

            User first = new User("Vasia", "Pupkin", "vasiapupkin359@int.pl", "779TjRse+nHLw$v", "from first user", "hello second user!", "reply for your messege 'second'");
            User second = new User("Pavel", "Morozov", "pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "from second user", "hello first user!", "reply for your messege 'first'");



           
     
            driver.Close();            
        }
    }
}