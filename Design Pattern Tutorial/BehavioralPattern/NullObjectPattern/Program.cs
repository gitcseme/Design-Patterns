using Autofac;
using ImpromptuInterface;
using System;
using System.Dynamic;

namespace NullObjectPattern
{
    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    public class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Warn(string msg)
        {
            Console.WriteLine("Warning: " + msg);
        }
    }
    
    // Null object do absolutely nothing........
    public class NullLog : ILog
    {
        public void Info(string msg)
        {
            
        }

        public void Warn(string msg)
        {
            
        }
    }

    // Dynamic Null object [uses ImpromptuInterface]
    // suppose ILog has 100 methods so we need to implement all of them and have to make sure they do nothing. 
    // In this case Dynamic null object helps us.
    public class Null<TInterface> : DynamicObject where TInterface : class
    {
        public static TInterface Instance // returns Any desired interface dynamically.
        {
            get
            {
                return new Null<TInterface>().ActLike<TInterface>();
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType); // If any member is called it will return default value.
            return true;
        }
    }


    public class BankAccount
    {
        private ILog log;
        private int Balance;
        public BankAccount(ILog log)
        {
            this.log = log;
        }

        public void Deposite(int amount)
        {
            Balance += amount;
            log.Info($"Deposited: {amount}, Balance: {Balance}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //var cLog = new ConsoleLog();
            //var ba = new BankAccount(cLog);
            //ba.Deposite(100);

            //var cb = new ContainerBuilder();
            //cb.RegisterType<BankAccount>();
            ////cb.RegisterType<ConsoleLog>().As<ILog>();
            //cb.RegisterType<NullLog>().As<ILog>();
            //using (var c = cb.Build())
            //{
            //    var ba = c.Resolve<BankAccount>();
            //    ba.Deposite(100);
            //}

            // Dynamic
            var log = Null<ILog>.Instance;
            var ba = new BankAccount(log);
            ba.Deposite(100);
        }
    }
}
