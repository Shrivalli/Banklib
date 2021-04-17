using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    class BankingException:ApplicationException
    {
        //Base Class Initialization
        public BankingException(string message):base(message)
        {

        }
    }
}
