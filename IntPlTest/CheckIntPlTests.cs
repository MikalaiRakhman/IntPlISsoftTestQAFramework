using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using IntISsoftTestQAFramework.Pages;
using IntISsoftTestQAFramework.Users;
using OpenQA.Selenium.Interactions;

namespace IntPlTest
{
    [TestClass]
    public class IntPlTests
    {
        IWebDriver driver;
        WebDriverWait wait;
        Actions actions;
        User first = new User("vasiapupkin359@int.pl", "779TjRse+nHLw$v", "from first user", "hello second user!", "reply for your messege 'second'");
        User second = new User("pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "from second user", "hello first user!", "reply for your messege 'first'");
        [TestInitialize] 
        public void Init() 
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            actions = new Actions(driver);
        }
        [TestMethod]
        public void TestLoginFirstUser()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));            
            MainPage mainPage = new MainPage(driver, wait, actions);
            MailPage mailPage = new MailPage(driver, wait, actions);
            mainPage.Login(first);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mailPage.GetAvatarButton())));
            bool isAvatarButttonAvailible = driver.FindElement(By.XPath(mailPage.GetAvatarButton())).Enabled;
            Assert.IsTrue(isAvatarButttonAvailible);
        }
        public void TestLoginSecondUser()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MainPage mainPage = new MainPage(driver, wait, actions);
            MailPage mailPage = new MailPage(driver, wait, actions);
            mainPage.Login(second);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mailPage.GetAvatarButton())));
            bool isAvatarButttonAvailible = driver.FindElement(By.XPath(mailPage.GetAvatarButton())).Enabled;
            Assert.IsTrue(isAvatarButttonAvailible);
        }
        [TestMethod]
        public void IntPlTestLogoutFirstUser() 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MainPage mainPage = new MainPage(driver, wait, actions);
            MailPage mailPage = new MailPage(driver, wait, actions);
            mainPage.Login(first);
            mailPage.Logout();
            bool isLoginButtonAvailible = driver.FindElement(By.XPath(mainPage.GetLoginButton())).Enabled;
            bool isInputMailAvailible = driver.FindElement(By.XPath(mainPage.GetInputMailPLaceHolder())).Enabled;
            bool isInputPasswordAvailible = driver.FindElement(By.XPath(mainPage.GetInputPasswordPLaceHolder())).Enabled;
            Assert.IsTrue(isInputPasswordAvailible && isInputMailAvailible && isLoginButtonAvailible);
        }
        [TestMethod]
        public void IntPlSendMessegeAndReplyMessegeTest1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MailPage mailPage = new MailPage(driver, wait, actions);
            MainPage mainPage = new MainPage(driver, wait, actions);
            mainPage.Login(first);
            Thread.Sleep(2000);
            mailPage.NewMessege();
            mailPage.CreateLetter(first, second, first.TextLetter);
            mailPage.SendLetter();
            Thread.Sleep(2000);
            mailPage.Logout();
            Thread.Sleep(1000);
            mainPage.Login(second);
            Thread.Sleep(2000);
            bool firstLetterArrivedAndCorrect = mailPage.CheckLetterFrom(first, first.TextLetter);
            mailPage.OpenReplyLetter();
            mailPage.CreateLetter(second, first, second.TextReplyLetter);
            mailPage.SendLetter();
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(1000);
            mainPage.Login(first);
            Thread.Sleep(5000);
            var replyLetterArrivedAndCorrect = mailPage.CheckLetterFrom(second, second.TextReplyLetter);
            mailPage.Logout();
            Assert.IsTrue(firstLetterArrivedAndCorrect && replyLetterArrivedAndCorrect);
        }
        [TestMethod]
        public void IntPlSendMessegeAndReplyMessegeTest2()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MailPage mailPage = new MailPage(driver, wait, actions);
            MainPage mainPage = new MainPage(driver, wait, actions);
            mainPage.Login(second);
            Thread.Sleep(2000);
            mailPage.NewMessege();
            mailPage.CreateLetter(second, first, second.TextLetter);
            mailPage.SendLetter();
            Thread.Sleep(2000);
            mailPage.Logout();
            Thread.Sleep(1000);
            mainPage.Login(first);
            Thread.Sleep(2000);
            bool firstLetterArrivedAndCorrect = mailPage.CheckLetterFrom(second, second.TextLetter);
            mailPage.OpenReplyLetter();
            mailPage.CreateLetter(first, second, first.TextReplyLetter);
            mailPage.SendLetter();
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(1000);
            mainPage.Login(second);
            Thread.Sleep(5000);
            var replyLetterArrivedAndCorrect = mailPage.CheckLetterFrom(first, first.TextReplyLetter);
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