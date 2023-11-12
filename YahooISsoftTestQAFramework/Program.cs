using IntISsoftTestQAFramework.Users;
using IntISsoftTestQAFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace IntISsoftTestQAFramework
{
    public class Program
    {    
        static void Main(string[] args)
        {
            /*В тестирующем проекте создайте автоматизированный тест для следующего тест-кейса:
	1. Выполните логин в почтовый сервис с использованием пароля и имени для первого пользователя.
	2. Создать письмо с произвольным телом и заголовком
	3. Отправить письмо на адрес второго зарегистрированного пользователя
	4. Выполнить выход из учетной записи первого пользователя
	5. Выполнить логин в почтовый сервис с использованием пароля и имени для второго пользователя.
	6. Выполнить логин в почтовый сервис с использованием пароля и имени для второго пользователя.
	7. Проверить что письмо с заданным на шаге 2 телом и заголовком получено. Если письмо еще не получено- выполнить ожидание, не более 10 минут.
	8. Ответить на письмо путем нажатия на кнопку Reply. Текст ответа произвольный
	9. Выполнить выход с учетной записи второго пользователя, выполнить вход с учетной записью первого пользователя и проверить что получен ответ с заданным текстом.*/
            IWebDriver driver = new ChromeDriver();
            MailPage mailPage = new MailPage(driver);
            MainPage mainPage = new MainPage(driver);

            User first = new User("Vasia", "Pupkin", "vasiapupkin359@int.pl", "779TjRse+nHLw$v", "from first user", "hello second user!", "reply for your messege 'second'");
            User second = new User("Pavel", "Morozov", "pavelmorozov302@int.pl", "x%Y%c78@/n!T.bx", "from second user", "hello first user!", "reply for your messege 'first'");

            mainPage.login(first);
            Thread.Sleep(5000);
            mailPage.CreateLetterAndSend(first);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(5000);
            mainPage.login(second);
            Thread.Sleep(5000);
            var result = mailPage.CheckLetterFrom(first);
            Thread.Sleep(5000);
            mailPage.ReplyLetter(second);
            Thread.Sleep(5000);
            mailPage.Logout();
            Thread.Sleep(5000);
            mainPage.login(first);
            Thread.Sleep(5000);
            var result2 = mailPage.CheckReplyLetterFrom(second);        
     
            driver.Close();            
        }
    }
}