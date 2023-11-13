using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using IntISsoftTestQAFramework.Pages;
using IntISsoftTestQAFramework.Users;

namespace IntPlTest
{
    [TestClass]
    public class IntPlTests
    {
        IWebDriver driver;
        User first = new User("vasiapupkin359@int.pl", "779TjRse+nHLw$v", "from first user", "hello second user!", "reply for your messege 'second'");
        User second = new User("pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "from second user", "hello first user!", "reply for your messege 'first'");

        [TestInitialize] 
        public void Init() 
        {
            driver = new ChromeDriver();
        }
        [TestMethod]
        public void TestLoginFirstUser()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));            
            MainPage mainPage = new MainPage(driver);
            MailPage mailPage = new MailPage(driver);
            mainPage.login(first);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mailPage.GetAvatarButton())));
            bool isAvatarButttonAvailible = driver.FindElement(By.XPath(mailPage.GetAvatarButton())).Enabled;
            Assert.IsTrue(isAvatarButttonAvailible);
        }
        public void TestLoginSecondUser()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MainPage mainPage = new MainPage(driver);
            MailPage mailPage = new MailPage(driver);
            mainPage.login(second);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mailPage.GetAvatarButton())));
            bool isAvatarButttonAvailible = driver.FindElement(By.XPath(mailPage.GetAvatarButton())).Enabled;
            Assert.IsTrue(isAvatarButttonAvailible);
        }

        [TestMethod]
        public void IntPlTestLogoutFirstUser() 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MainPage mainPage = new MainPage(driver);
            MailPage mailPage = new MailPage(driver);
            mainPage.login(first);
            mailPage.Logout();
            bool isLoginButtonAvailible = driver.FindElement(By.XPath(mainPage.GetLoginButton())).Enabled;
            bool isInputMailAvailible = driver.FindElement(By.XPath(mainPage.GetInputMailPLaceHolder())).Enabled;
            bool isInputPasswordAvailible = driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).Enabled;
            Assert.IsTrue(isInputPasswordAvailible && isInputMailAvailible && isLoginButtonAvailible);
        }
        [TestMethod]
/*
	1. Выполните логин в почтовый сервис с использованием пароля и имени для первого пользователя.
	2. Создать письмо с произвольным телом и заголовком
	3. Отправить письмо на адрес второго зарегистрированного пользователя
	4. Выполнить выход из учетной записи первого пользователя
	5. Выполнить логин в почтовый сервис с использованием пароля и имени для второго пользователя.
	6. Выполнить логин в почтовый сервис с использованием пароля и имени для второго пользователя.
	7. Проверить что письмо с заданным на шаге 2 телом и заголовком получено. Если письмо еще не получено- выполнить ожидание, не более 10 минут.
	8. Ответить на письмо путем нажатия на кнопку Reply. Текст ответа произвольный
	9. Выполнить выход с учетной записи второго пользователя, выполнить вход с учетной записью первого пользователя и проверить что получен ответ с заданным текстом.*/
        public void IntPlSendMessegeAndReplyMessegeTest1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MailPage mailPage = new MailPage(driver);
            MainPage mainPage = new MainPage(driver);
            mainPage.login(first);
            Thread.Sleep(5000);
            mailPage.CreateLetterAndSend(first, second);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(5000);
            mainPage.login(second);
            Thread.Sleep(5000);
            bool firstLetterArrivedAndCorrect = mailPage.CheckLetterFrom(first);
            mailPage.ReplyLetterFrom(second);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(5000);
            mainPage.login(first);
            Thread.Sleep(5000);
            bool replyLetterArrivedAndCorrect = mailPage.CheckReplyLetterFrom(second);
            mailPage.Logout();

            Assert.IsTrue(firstLetterArrivedAndCorrect && replyLetterArrivedAndCorrect);
        }


        [TestMethod]
        public void IntPlSendMessegeAndReplyMessegeTest2()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MailPage mailPage = new MailPage(driver);
            MainPage mainPage = new MainPage(driver);
            mainPage.login(second);
            Thread.Sleep(5000);
            mailPage.CreateLetterAndSend(second, first);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(5000);
            mainPage.login(first);
            Thread.Sleep(5000);
            bool firstLetterArrivedAndCorrect = mailPage.CheckLetterFrom(second);
            mailPage.ReplyLetterFrom(first);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(5000);
            mainPage.login(second);
            Thread.Sleep(5000);
            bool replyLetterArrivedAndCorrect = mailPage.CheckReplyLetterFrom(first);
            mailPage.Logout();
            Assert.IsTrue(firstLetterArrivedAndCorrect && replyLetterArrivedAndCorrect);
        }



        [TestCleanup]
        public void Cleanup()
        {
            driver.Dispose();
        }

        
    }
}