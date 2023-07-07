using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Singleton
{
    internal class SingletonDatabaseDemo
    {
        public interface IDatabase
        {
            int GetPopulation(string name);
        }
        public class SingletonDatabase : IDatabase
        {
            private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
            public static SingletonDatabase Instance = instance.Value;

            private Dictionary<string, int> capitals;
            private SingletonDatabase()
            {
                Console.WriteLine("Initialization SignletonDatabase..");
                capitals = File.ReadAllLines(
                            Path.Combine(
                            new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"))
                            .Batch(2)
                            .ToDictionary(
                            list => list.ElementAt(0).Trim(),
                            list => int.Parse(list.ElementAt(1)));
            }

            public int GetPopulation(string name)
            {
                return capitals[name];
            }
        }

        static void Main()
        {
            var db = SingletonDatabase.Instance;

            // works just fine while you're working with a real database.
            var city = "Tokyo";
            Console.WriteLine($"{city} has population {db.GetPopulation(city)}");

            // now some tests
        }
    }
}
