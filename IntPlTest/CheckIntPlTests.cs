using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using IntISsoftTestQAFramework.Pages;
using IntISsoftTestQAFramework.Users;
namespace IntPlTest
{
    [TestClass]
    public class IntPlTests
    {
        IWebDriver driver;        
        MainPage mainPage;
        MailPage mailPage;
        User first;
        User second;
        [TestInitialize] 
        public void Init() 
        {
            driver = new ChromeDriver();
            mailPage = new MailPage(driver);
            mainPage = new MainPage(driver);
            first = new User("vasiapupkin359@int.pl", "779TjRse+nHLw$v", "hello second user!", "reply for your messege 'second'");
            second = new User("pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "hello first user!", "reply for your messege 'first'");
        }
        [TestMethod]
        public void TestLoginFirstUser()
        {            
            mainPage.Login(first);            
            Assert.IsTrue(mailPage.IsAvatarButtonEnabled());
        }
        public void TestLoginSecondUser()
        {
            mainPage.Login(second);            
            Assert.IsTrue(mailPage.IsAvatarButtonEnabled());
        }
        [TestMethod]
        public void IntPlTestLogoutFirstUser() 
        {
            mainPage.Login(first);
            mailPage.Logout();            
            Assert.IsTrue(mainPage.IsInputPasswordPlaceholderEnabled() && mainPage.IsInputMailPlaceholderEnabled() && mainPage.IsLoginButtonEnabled());
        }
        [TestMethod]
        public void IntPlSendMessegeAndReplyMessegeTest1()
        {
            mainPage.Login(first);           
            mailPage.NewMessege();
            mailPage.CreateLetter(first, second, first.TextLetter);
            mailPage.SendLetter();            
            mailPage.Logout();            
            mainPage.Login(second);            
            Assert.IsTrue(mailPage.CheckLetterFrom(first, first.TextLetter));
            mailPage.OpenReplyLetter();
            mailPage.CreateLetter(second, first, second.TextReplyLetter);
            mailPage.SendLetter();            
            mailPage.Logout();            
            mainPage.Login(first);            
            Assert.IsTrue(mailPage.CheckLetterFrom(second, second.TextReplyLetter));
            mailPage.Logout();            
        }
        [TestMethod]
        public void IntPlSendMessegeAndReplyMessegeTest2()
        {
            mainPage.Login(second);            
            mailPage.NewMessege();
            mailPage.CreateLetter(second, first, second.TextLetter);
            mailPage.SendLetter();            
            mailPage.Logout();            
            mainPage.Login(first);            
            Assert.IsTrue(mailPage.CheckLetterFrom(second, second.TextLetter));
            mailPage.OpenReplyLetter();
            mailPage.CreateLetter(first, second, first.TextReplyLetter);
            mailPage.SendLetter();            
            mailPage.Logout();            
            mainPage.Login(second);            
            Assert.IsTrue(mailPage.CheckLetterFrom(first, first.TextReplyLetter));
            mailPage.Logout();            
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }        
    }
}