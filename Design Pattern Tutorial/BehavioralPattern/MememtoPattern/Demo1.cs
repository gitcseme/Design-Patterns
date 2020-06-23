using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

/**
 *     Store a particular state of an object.
 */

namespace MememtoPattern
{
    public class Memento
    {
        public int Balance { get; }
        public Memento(int balance)
        {
            Balance = balance;
        }
    }

    public class BankAccount
    {
        private int Balance;
        private List<Memento> changes = new List<Memento>();
        private int current;

        public BankAccount(int balance)
        {
            Balance = balance;
            changes.Add(new Memento(Balance));
            current = 0;
        }

        public Memento Deposite(int amount)
        {
            Balance += amount;
            var m = new Memento(Balance);
            changes.Add(m);
            ++current;
            return m;
        }

        public Memento Restore(Memento m)
        {
            if (m != null)
            {
                Balance = m.Balance;
                changes.Add(m);
                return m;
            }
            return null;
        }

        public Memento Undo()
        {
            if (current > 0)
            {
                var m = changes[--current];
                Balance = m.Balance;
                return m;
            }
            return null;
        }
        
        public Memento Redo()
        {
            if (current + 1 < changes.Count)
            {
                var m = changes[++current];
                Balance = m.Balance;
                return m;
            }
            return null;
        }


        public override string ToString() => $"Balance: {Balance}";
    }

    class Demo1
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount(100);
            ba.Deposite(50);
            ba.Deposite(25);
            Console.WriteLine(ba);

            ba.Undo();
            Console.WriteLine($"Undo 1: {ba}");
            ba.Undo();
            Console.WriteLine($"Undo 2: {ba}");
            ba.Redo();
            Console.WriteLine($"Redo 1: {ba}");
        }
    }
}
