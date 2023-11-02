using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooISsoftTestQAFramework
{
    internal class SecondUserYahoo : UsersYahoo
    {
        string _firstName { get; }
        string _lastName { get; }
        string _mailAdress { get; }
        string _password { get; }
        string _phoneNumber { get; }
        public SecondUserYahoo() 
        {
            _firstName = "Pavel";
            _lastName = "Morozov";
            _mailAdress = "pavelmorozov302@yahoo.com";
            _password = "x%Y%c78@/n!T.bx";
            _phoneNumber = "572057407";
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
