using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    interface IBankRepository
    {
        void NewAccount(SBAccount acc);
        SBAccount GetAccountDetails(int accno);
        List<SBAccount> GetAllAccounts();
        double DepositAmount(int accno, decimal amt);
        double WithdrawAmount(int accno, decimal amt);
        List<SBTransaction> GetTransactions(int accno);
    }
}
