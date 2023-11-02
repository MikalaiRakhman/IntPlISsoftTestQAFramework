using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooISsoftTestQAFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            // открыть главную страницу
             IWebDriver driver = new ChromeDriver();
             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
             YahooMainPage yahooMainPage = new YahooMainPage(driver, wait);
             yahooMainPage.AcceptCookies();

            FirstUserYahoo firstUserYahoo = new FirstUserYahoo();
            string name = firstUserYahoo.GetLastName();
            
            // открыть логин страницу
            /*IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            YahooLoginPage loginPage = new YahooLoginPage(driver, wait);
            */
            // открыть мэйл страницу невозможно, если не залогинен
            /*IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            YahooMailPage mailPage = new YahooMailPage(driver, wait);
            driver.FindElement(By.XPath("//button[@class='btn secondary accept-all ']")).Click();
            */
            
            driver.Close();
            
        }
    }

}