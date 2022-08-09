using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace c_sharp
{
    class Program
    {
        static void Main()
        {
            var calculate = new Calculate(Sum);
            var result  = calculate(10,20);
            Console.WriteLine(result);
        }
    }

    delegate int Calculate (int x, int y);

    class FileLogger : ILogger
    {
        private readonly string filePath;
        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void log(string message)
        {
            File.AppendAllText(filePath, $"{message}{Environment.NewLine}");
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
