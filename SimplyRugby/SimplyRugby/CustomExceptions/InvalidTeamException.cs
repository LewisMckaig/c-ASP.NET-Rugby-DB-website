using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyRugby.CustomExceptions
{
    public class InvalidTeamException : Exception
    {
        public InvalidTeamException()
        {

        }

        public InvalidTeamException(String message)
        : base(message)
        { 
        }
    }
}