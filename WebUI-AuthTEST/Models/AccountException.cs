using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI_AuthTEST.Models
{
    public class AccountException : Exception
    {
        public AccountException(string message) : base(message)
        {
        }
    }
}