namespace IntISsoftTestQAFramework.Users
{
    public class User
    {
        public string FirstName {  get; }
        public string LastName { get; }        
        public string MailAdress { get; }
        public string Password { get; }
        public string ThemeLetter { get; }
        public string TextLetter { get; }
        public string ThemeTextReplyLetter { get; }
        public User(string firstName, string lastName, string mailAdres, string password, string themeLetter, string textLetter, string themeTextReplyLetter)
        {
            FirstName = firstName;
            LastName = lastName;
            MailAdress = mailAdres;
            Password = password;
            ThemeLetter = themeLetter;
            ThemeTextReplyLetter = themeTextReplyLetter;
        }
    }
}
