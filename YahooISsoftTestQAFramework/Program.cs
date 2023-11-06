using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace IntISsoftTestQAFramework
{
    public class Program
    {
     
        static void Main(string[] args)
        {           
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            SecondUserIntPl second = new SecondUserIntPl(driver, wait);
            Actions actions = new Actions(driver);

            //second.Login();
           // first.Login();
            //first.CreateLetter();
            //first.Logout();
            //Thread.Sleep(5000);
            second.Login();
     
            driver.Close();
            
        }
    }

}