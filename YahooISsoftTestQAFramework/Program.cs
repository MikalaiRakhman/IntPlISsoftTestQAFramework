﻿using IntISsoftTestQAFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.Target;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SeleniumExtras.WaitHelpers;

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


            first.Login();
            first.CreateLetter();
            first.Logout();


            driver.Close();
            
           





            
            
        }
    }

}