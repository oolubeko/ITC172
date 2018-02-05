using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistMVC2018.Models
{
    public class LoginClass
    {
        public LoginClass() { }
        public LoginClass(string user, string password)
        {
            UserName = user;
            PassWord = password;
        }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}