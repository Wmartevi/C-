using System;
using System.IO;

namespace c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ILogger logger = new FileLogger();
            ILogger logger = new ConsoleLogger();
            BankAccount account1 = new BankAccount("Carlos", 100, logger);
            BankAccount account2 = new BankAccount("Julia", 250, logger);

            account1.Deposit(0);
            account2.Deposit(100);

            Console.WriteLine(account2.Balance);

            
            
        }
    }

    class FileLogger : ILogger
    {
        public void log(string message)
        {
            File.AppendAllText("log.txt", $"{message}{Environment.NewLine}");
        }
    }

    class ConsoleLogger : ILogger
    {
    }

    interface ILogger
    {
        void log(string message)
        {
            Console.WriteLine($"LOGGER: {message}");
        }
    }

    class BankAccount
    {
        private string name;
        private readonly ILogger logger;

        public decimal Balance 
        { 
            get; private set;
        }

        public BankAccount(string name, decimal balance, ILogger logger)
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
            Balance = balance;
            this.logger = logger;
        }

        public void Deposit (decimal amount)
        {
            if (amount <= 0)
            {
                logger.log($"Não é possível depositar {amount} na conta de {name}");
            }
            Balance += amount;
        }

       /* public decimal GetBalance()
        {
            return balance;
        }*/
    }

}
