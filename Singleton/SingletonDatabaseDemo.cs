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
        public class SingletonDatabase
        {
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
        }
    }
}
