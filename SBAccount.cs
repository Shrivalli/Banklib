using System;
using System.Xml.Serialization;

namespace BankLibrary
{
    
    public class SBAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public double CurrentBalance { get; set; }

        public override string ToString()
        {
            return string.Format(CustomerName + " " + AccountNumber + ": " + CurrentBalance);
        }
    }


}
