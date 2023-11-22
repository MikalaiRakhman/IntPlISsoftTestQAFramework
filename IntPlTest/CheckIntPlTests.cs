using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using IntISsoftTestQAFramework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using IntISsoftTestQAFramework.Pages;

namespace IntPlTest
{
    [TestClass]
    public class IntPlTests
    {
        IWebDriver driver;

        [TestInitialize] 
        public void Init() 
        {
            driver = new ChromeDriver();

        }

        [TestMethod]
        public void IntPlTestLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            IntPlMailPage mailPage = new IntPlMailPage(driver);
            first.Login();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mailPage.GetMailAvatarButton())));
            bool isAvatarButttonAvailible = driver.FindElement(By.XPath(mailPage.GetMailAvatarButton())).Enabled;
            Assert.IsTrue(isAvatarButttonAvailible);

        }

        [TestMethod]
        public void IntPlTestLogout() 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            IntPlMainPage mainPage = new IntPlMainPage(driver);
            first.Login();
            first.Logout();
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
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            SecondUserIntPl second = new SecondUserIntPl(driver, wait);
            first.Login();
            Thread.Sleep(5000);
            first.CreateLetter();
            Thread.Sleep(5000);
            first.Logout();
            Thread.Sleep(5000);
            second.Login();
            Thread.Sleep(5000);
            bool firstLetterArrivedAndCorrect = second.CheckLetter();
            second.ReplyLetter();
            Thread.Sleep(5000);
            second.Logout();
            Thread.Sleep(5000);
            first.Login();
            Thread.Sleep(5000);
            bool replyLetterArrivedAndCorrect = first.CheckReplyLetter();
            first.Logout();

            Assert.IsTrue(firstLetterArrivedAndCorrect && replyLetterArrivedAndCorrect);
        }


        [TestMethod]
        public void IntPlSendMessegeAndReplyMessegeTest2()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            FirstUserIntPl first = new FirstUserIntPl(driver, wait);
            SecondUserIntPl second = new SecondUserIntPl(driver, wait);
            second.Login();
            Thread.Sleep(5000);
            second.CreateLetter();
            Thread.Sleep(5000);
            second.Logout();
            Thread.Sleep(5000);
            first.Login();
            Thread.Sleep(5000);
            bool firstLetterArrivedAndCorrect = first.CheckLetter();
            first.ReplyLetter();
            Thread.Sleep(5000);
            first.Logout();
            Thread.Sleep(5000);
            second.Login();
            Thread.Sleep(5000);
            bool replyLetterArrivedAndCorrect = second.CheckReplyLetter();
            second.Logout();

            Assert.IsTrue(firstLetterArrivedAndCorrect && replyLetterArrivedAndCorrect);
        }



        [TestCleanup]
        public void Cleanup()
        {
            driver.Dispose();
        }

        
    }
}