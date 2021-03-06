﻿using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SingletonPattern
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> Capitals;

        private SingletonDatabase()
        {
            Console.WriteLine("Initiliging database");
            Capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    k => k.ElementAt(0), 
                    v => int.Parse(v.ElementAt(1))
                );
        }

        // <me>
        private static SingletonDatabase DbInstance;
        public static SingletonDatabase GetDatabaseInstance()
        {
            if (DbInstance == null) {
                DbInstance = new SingletonDatabase();
            }
            return DbInstance;
        }
        // </me>

        public int GetPopulation(string name)
        {
            return Capitals[name];
        }

        private static Lazy<SingletonDatabase> instance = 
            new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            SingletonDatabase db = SingletonDatabase.Instance;
            var city = "Tokyo";

            SingletonDatabase db2 = SingletonDatabase.Instance;

            var city2 = "Delhi";
            Console.WriteLine($"{city}: {db.GetPopulation(city)}");
            Console.WriteLine($"{city2}: {db2.GetPopulation(city2)}");
        }
    }
}
