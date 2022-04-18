using System;

namespace c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Carlos", 100);
            BankAccount account2 = new BankAccount("Julia", 250);
            
        }
    }
    class BankAccount
    {
        private string name;
        private decimal balance;

        public BankAccount(string name, decimal balance)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException ("Nome inválido", nameof(name));
            }

            if (balance < 0)
            {
                throw new Exception("Saldo não pode ser negativo.");
            }

            this.name = name;
            this.balance = balance;
        }

        public void Deposit (decimal amount)
        {
            balance += amount;
        }
    }

}
