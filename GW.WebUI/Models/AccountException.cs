using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GW.WebUI.Models
{
    public class AccountException : Exception
    {
        public AccountException(string message) : base(message)
        {
        }
    }
}