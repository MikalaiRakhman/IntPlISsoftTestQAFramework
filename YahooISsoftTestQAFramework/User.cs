namespace IntISsoftTestQAFramework.Users
{
    public class User
    {   
        public string MailAdress { get; }
        public string Password { get; }        
        public string TextLetter { get; }
        public string TextReplyLetter { get; }
        public User( string mailAdres, string password, string textLetter, string textReplyLetter)
        {
            MailAdress = mailAdres;
            Password = password;                        
            TextLetter = textLetter;
            TextReplyLetter = textReplyLetter;
        }
    }
}
