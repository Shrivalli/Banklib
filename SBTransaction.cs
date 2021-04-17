using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
   public class SBTransaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountNumber { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
    }
}
