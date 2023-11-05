using IntISsoftTestQAFramework.Pages;
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
using IntISsoftTestQAFramework.Users;

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

            

            // Выполните логин в почтовый сервис с использованием пароля и имени для первого пользователя.
            second.Login();
            Thread.Sleep(5000);
            // Создать письмо с произвольным телом и заголовком
            // Отправить письмо на адрес второго зарегистрированного пользователя
            second.CreateLetter();
            Thread.Sleep(5000);
            // Выполнить выход из учетной записи первого пользователя
            second.Logout();
            Thread.Sleep(5000);
            // Выполнить логин в почтовый сервис с использованием пароля и имени для второго пользователя.
            first.Login();
            Thread.Sleep(5000);
            // Проверить что письмо с заданным на шаге 2 телом и заголовком получено.
            bool res1 = first.CheckLetter();
            Thread.Sleep(5000);
            //Ответить на письмо путем нажатия на кнопку Reply. Текст ответа произвольный
            first.ReplyLetter();
            Thread.Sleep(5000);
            //Выполнить выход с учетной записи второго пользователя, выполнить вход с учетной записью первого пользователя и проверить что получен ответ с заданным текстом.
            first.Logout();
            Thread.Sleep(15000);
            second.Login();
            Thread.Sleep(5000);
            bool res2 = second.CheckReplyLetter();
            Thread.Sleep(5000);

            driver.Close();
            
           





            
            
        }
    }

}