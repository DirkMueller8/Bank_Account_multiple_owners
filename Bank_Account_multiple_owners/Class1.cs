using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_multiple_owners
{
    internal class BankAccount
    {
        public string accNumber { get; }
        public string accOwner { get; set;  }
        private int accNumberSeed = 1234567890;
        List<Transaction> allTransactions = new List<Transaction>();
        public BankAccount(string owner, decimal initialDeposit)
        {
            accNumber = accNumberSeed++.ToString();
            accOwner = owner;
            MakeDeposit(initialDeposit, DateTime.Now, "Initial deposit");
        }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.amount;
                }
                return balance; 
            }
        }

        public void MakeDeposit(decimal amount, DateTime date, string notes)
        {
            Transaction transaction = new Transaction(DateTime.Now, amount, notes);
            allTransactions.Add(transaction);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string notes)
        {
            Transaction transaction = new Transaction(DateTime.Now, -amount, notes);
            allTransactions.Add(transaction);
        }
        public string GetAccountHistory()
        {
            decimal balance = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Owner: {accOwner}");
            sb.AppendLine("Date\t\tAmount\tBalance\tNotes");
            foreach (var trans in allTransactions)
            {
                balance += trans.amount;
                sb.AppendLine($"{trans.date.ToShortDateString()}\t{trans.amount}\t{balance}\t{trans.notes}");
            }
            return sb.ToString();
        }
        public class Transaction
        {
            public DateTime date { get; }
            public decimal amount { get; }
            public string notes { get; }
            public Transaction(DateTime date, decimal amount, string notes)
            {
                this.date = date;
                this.amount = amount;
                this.notes = notes;
            }
        }
    }
}
