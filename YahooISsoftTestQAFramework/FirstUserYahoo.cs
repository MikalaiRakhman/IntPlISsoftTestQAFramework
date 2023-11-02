using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooISsoftTestQAFramework
{
    internal class FirstUserYahoo : UsersYahoo
    {
        string _firstName {  get;  }
        string _lastName {  get; }
        string _mailAdress {  get; }
        string _password { get; }
        string _phoneNumber { get; }



        public FirstUserYahoo() 
        {

            _firstName = "Vasia";
            _lastName = "Pupkin";
            _mailAdress = "vasiapupkin359@yahoo.com";
            _password = "779TjRse+nHLw$v";
            _phoneNumber = "572068230";


        }

        public override string GetFirstName() 
        {
            return _firstName;
        }

        public override string GetLastName() 
        {
            return _lastName;
        }

        public override string GetMailAdress() 
        {
            return _mailAdress; 
        }

        public override string GetPassword() 
        {
            return _password;
        }

        public override string GetPhoneNumber() 
        {
            return _phoneNumber; 
        }
    }
}
