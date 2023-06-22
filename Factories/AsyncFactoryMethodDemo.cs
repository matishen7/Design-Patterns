using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factories
{
    public class AsyncFactoryMethodDemo
    {
        public class Foo
        {
            public static async Task<Foo> CreateAsync()
            {
                var result = new Foo();
                return await result.InitAsync();
            }
            private async Task<Foo> InitAsync()
            {
                await Task.Delay(2000);
                return this;
            }
            private Foo()
            {

            }
        }

        public class DataProcessor
        {
            public static async Task<DataProcessor> CreateDataProcessor()
            {
                var result = new DataProcessor();
                var instance = await result.FetchDataFromDatabase();
                return instance;
            }
            private async Task<DataProcessor> FetchDataFromDatabase()
            {
                await Task.Delay(5000);
                return this;
            }
            private DataProcessor()
            {

            }
        }

        public static void Main(string[] args)
        {
            var foo = Foo.CreateAsync();
            Console.WriteLine(foo);
            var dp = DataProcessor.CreateDataProcessor();
            Console.WriteLine(dp);
        }


    }
}
