using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

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
                else
                {
                    throw new BankingException("Sorry Account number not present");
                }
            }
            return null;
        }

        public List<SBAccount> GetAllAccounts()
        {
            #region
            //   List<SBAccount> sl = new List<SBAccount>();
            //   SBAccount s = new SBAccount();
            FileStream fs = new FileStream(@"H:\C#\BankData2.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            StringBuilder sb = new StringBuilder();
            string s1 = sr.ReadToEnd();
            SBAccount s = JsonConvert.DeserializeObject<SBAccount>(s1);
            salist.Add(s);
            return salist;
            //   System.Xml.Serialization.XmlSerializer reader =
            //new System.Xml.Serialization.XmlSerializer(typeof(SBAccount));
            //   System.IO.StreamReader file = new System.IO.StreamReader(@"H:\C#\BankData.xml");
            //   s = (SBAccount)reader.Deserialize(file);
            //   file.Close();
            //   sl.Add(s);
            //   return sl;
            #endregion
           // return salist;
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
               foreach(var it in stlist)
                    {
                        if (it.AccountNumber == accno)
                        {
                            List<SBTransaction> slist = new List<SBTransaction>();
                            slist.Add(it);
                            return slist;
                        }
                        else
                        {
                            throw new BankingException("Sorry Account Number does not exist");
                        }
                    }
            return null;
        }

        public void NewAccount(SBAccount acc)
        {
            salist.Add(acc);
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"H:\c#\BankData2.txt",true))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, acc);
            }
        }

        public double WithdrawAmount(int accno, decimal amt)
        {
           foreach(SBAccount item in salist)
            {
                if(item.AccountNumber==accno)
                {
                    if(item.CurrentBalance<Convert.ToDouble(amt))
                    {
                        throw new BankingException("Not Enough Money");
                    }
                    else
                    {
                        item.CurrentBalance-=Convert.ToDouble(amt);
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
                
            }
            return 0;
        }
    }
}
