using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankLibrary
{
   public class BankRepository : IBankRepository
    {
       public static List<SBAccount> salist = new List<SBAccount>();
        public static List<SBTransaction> stlist = new List<SBTransaction>();
        public static int ctr = 0;
        public double DepositAmount(int accno, decimal amt)
        {
            foreach(SBAccount item in salist)
            {
                if(item.AccountNumber==accno)
                {
                    item.CurrentBalance += Convert.ToDouble(amt);
                    SBTransaction t = new SBTransaction();
                    t.TransactionId = ctr + 1;
                    t.TransactionDate = DateTime.Now;
                    t.TransactionType = "Savings";
                    t.AccountNumber = accno;
                    t.Amount = Convert.ToDouble(amt);
                    stlist.Add(t);
                    return item.CurrentBalance;
                }
                
            }
            return 0;
        }

        public SBAccount GetAccountDetails(int accno)
        {
            foreach(SBAccount item in salist)
            {
                if(item.AccountNumber==accno)
                {
                    return item;
                }
            }
            return null;
        }

        public List<SBAccount> GetAllAccounts()
        {
            return salist;
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            foreach(var item in stlist)
            {
                if(item.AccountNumber==accno)
                {
                    // var result = stlist.Where(x => x.AccountNumber == accno).Select(x => x).ToList();
                    return stlist;
                }
            }
            return null;
        }

        public void NewAccount(SBAccount acc)
        {
            salist.Add(acc);

        }

        public double WithdrawAmount(int accno, decimal amt)
        {
           foreach(SBAccount item in salist)
            {
                if(item.AccountNumber==accno)
                {
                    if(item.CurrentBalance<Convert.ToDouble(amt))
                    {
                        throw new Exception("Not Enough Money");
                    }
                    else
                    {
                        item.CurrentBalance-=Convert.ToDouble(amt);
                        return item.CurrentBalance;
                    }
                }
                
            }
            return 0;
        }
    }
}
