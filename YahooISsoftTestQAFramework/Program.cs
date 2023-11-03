using IntISsoftTestQAFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntISsoftTestQAFramework
{
    public class Program
    {
     
        static void Main(string[] args)
        {

            
            
            IWebDriver driver = new ChromeDriver();
            IWebDriver driver2 = new ChromeDriver();
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
  
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            SecondUserIntPl second = new SecondUserIntPl(driver2, wait);
            second.Login();
            first.Login();
            
            driver.Close();
            driver2.Close();
           





            
            
        }
    }

}