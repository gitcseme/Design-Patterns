using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPattern
{
    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposite(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount}, current balance {balance}");
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw {amount}, current balance {balance}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Balance: {balance}";
        }
    }

    public interface ICommand
    {
        void Call();
        void Undo();
    }

    public class BankAccountCommand : ICommand
    {
        private BankAccount account;
        private Action action;
        private int amount;
        private bool succeeded;


        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }

        public enum Action
        {
            Deposite, Withdraw
        }

        public void Call()
        {
            switch(action)
            {
                case Action.Deposite:
                    account.Deposite(amount);
                    succeeded = true;
                    break;
                case Action.Withdraw:
                    succeeded = account.Withdraw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            if (!succeeded) return;
            switch(action)
            {
                case Action.Deposite:
                    account.Withdraw(amount);
                    break;
                case Action.Withdraw:
                    account.Deposite(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>()
            {
                new BankAccountCommand(ba, BankAccountCommand.Action.Deposite, 100),
                new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 1000)
            };

            Console.WriteLine(ba);
            foreach (var c in commands)
                c.Call();
            Console.WriteLine(ba);

            foreach (var c in Enumerable.Reverse(commands))
                c.Undo();
            Console.WriteLine(ba);
        }
    }
}
