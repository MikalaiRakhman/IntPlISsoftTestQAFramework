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
        User first = new User("Vasia", "Pupkin", "vasiapupkin359@int.pl", "779TjRse+nHLw$v", "from first user", "hello second user!", "reply for your messege 'second'");
        User second = new User("Pavel", "Morozov", "pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "from second user", "hello first user!", "reply for your messege 'first'");

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
	1. ��������� ����� � �������� ������ � �������������� ������ � ����� ��� ������� ������������.
	2. ������� ������ � ������������ ����� � ����������
	3. ��������� ������ �� ����� ������� ������������������� ������������
	4. ��������� ����� �� ������� ������ ������� ������������
	5. ��������� ����� � �������� ������ � �������������� ������ � ����� ��� ������� ������������.
	6. ��������� ����� � �������� ������ � �������������� ������ � ����� ��� ������� ������������.
	7. ��������� ��� ������ � �������� �� ���� 2 ����� � ���������� ��������. ���� ������ ��� �� ��������- ��������� ��������, �� ����� 10 �����.
	8. �������� �� ������ ����� ������� �� ������ Reply. ����� ������ ������������
	9. ��������� ����� � ������� ������ ������� ������������, ��������� ���� � ������� ������� ������� ������������ � ��������� ��� ������� ����� � �������� �������.*/
        public void IntPlSendMessegeAndReplyMessegeTest1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            MailPage mailPage = new MailPage(driver);
            MainPage mainPage = new MainPage(driver);
            mainPage.login(first);
            Thread.Sleep(5000);
            mailPage.CreateLetterAndSend(first);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(5000);
            mainPage.login(second);
            Thread.Sleep(5000);
            bool firstLetterArrivedAndCorrect = mailPage.CheckLetterFrom(first);
            mailPage.ReplyLetter(second);
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
            mailPage.CreateLetterAndSend(second);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(5000);
            mainPage.login(first);
            Thread.Sleep(5000);
            bool firstLetterArrivedAndCorrect = mailPage.CheckLetterFrom(second);
            mailPage.ReplyLetter(first);
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