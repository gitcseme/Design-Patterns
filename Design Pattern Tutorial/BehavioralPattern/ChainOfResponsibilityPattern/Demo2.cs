using System;
using System.Collections.Generic;
using System.Text;
using static ChainOfResponsibilityPattern.EnumHolder;

namespace ChainOfResponsibilityPattern
{
    public class EnumHolder
    {
        public enum OperationType
        {
            Add,
            Sub,
            Mul
        }
    }

    public class Numbers
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public OperationType operationType;

        public Numbers(int Num1, int Num2, OperationType operationType)
        {
            this.Num1 = Num1;
            this.Num2 = Num2;
            this.operationType = operationType;
        }
    }

    public class Chain
    {
        protected Chain next;
        public Chain AddToChain(Chain node)
        {
            if (next == null)
                next = node;
            else
                next.AddToChain(node);

            return this;
        }

        public virtual string Calculate(Numbers numbers)
        {
            return next?.Calculate(numbers);
        }
    }

    public class Addition : Chain
    {
        public override string Calculate(Numbers numbers)
        {
            if (numbers.operationType == OperationType.Add)
            {
                int res = numbers.Num1 + numbers.Num2;
                return $"{numbers.Num1} + {numbers.Num2} = {res}";
            }
            else
            {
                if (next == null)
                    return "OperationType is unrecognized";
                else
                    return next.Calculate(numbers);
            }
        }
    }

    public class Subtraction : Chain
    {
        public override string Calculate(Numbers numbers)
        {
            if (numbers.operationType == OperationType.Sub)
            {
                int res = numbers.Num1 - numbers.Num2;
                return $"{numbers.Num1} - {numbers.Num2} = {res}";
            }
            else
            {
                if (next == null)
                    return "OperationType is unrecognized";
                else
                    return next.Calculate(numbers);
            }
        }
    }

    public class Multiplication : Chain
    {
        public override string Calculate(Numbers numbers)
        {
            if (numbers.operationType == OperationType.Mul)
            {
                int res = numbers.Num1 * numbers.Num2;
                return $"{numbers.Num1} * {numbers.Num2} = {res}";
            }
            else
            {
                if (next == null)
                    return "OperationType is unrecognized";
                else
                    return next.Calculate(numbers);
            }
        }
    }

    public class Demo2
    {
        static void Main(string[] args)
        {
            var chain = new Chain();
            chain.AddToChain(new Addition())
                .AddToChain(new Subtraction())
                .AddToChain(new Multiplication());

            Numbers numbers = new Numbers(5, 10, OperationType.Mul);
            var result = chain.Calculate(numbers);
            Console.WriteLine(result);
        }
    }
}
