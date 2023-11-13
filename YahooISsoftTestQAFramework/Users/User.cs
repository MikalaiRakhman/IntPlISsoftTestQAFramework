namespace IntISsoftTestQAFramework.Users
{
    public class User
    {   
        public string MailAdress { get; }
        public string Password { get; }
        public string ThemeLetter { get; }
        public string TextLetter { get; }
        public string TextReplyLetter { get; }
        public User( string mailAdres, string password, string themeLetter, string textLetter, string textReplyLetter)
        {
            MailAdress = mailAdres;
            Password = password;
            ThemeLetter = themeLetter;            
            TextLetter = textLetter;
            TextReplyLetter = textReplyLetter;
        }
    }
}
