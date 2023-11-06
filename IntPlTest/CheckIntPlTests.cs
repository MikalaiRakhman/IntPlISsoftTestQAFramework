using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using IntISsoftTestQAFramework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading.Channels;

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


        [TestCleanup]
        public void Cleanup()
        {
            driver.Dispose();
        }
    }
}