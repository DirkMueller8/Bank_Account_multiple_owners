namespace Bank_Account_multiple_owners
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("Dirk", 1000);
            bankAccount.MakeWithdrawal(200, DateTime.Now, "Licence");
            bankAccount.MakeDeposit(400, DateTime.Now, "Salary");
            Console.WriteLine(bankAccount.GetAccountHistory());
        }
    }
}