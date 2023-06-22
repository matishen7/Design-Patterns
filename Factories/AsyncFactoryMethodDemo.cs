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

        public static void Main(string[] args)
        {
            var foo = Foo.CreateAsync();
            Console.WriteLine(foo);
        }
    }
}
