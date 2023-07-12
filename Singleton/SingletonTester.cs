using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Design_Patterns.Singleton.AmbientContextDemo;

namespace Design_Patterns.Singleton
{
    internal class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            object obj1 = func();
            object obj2 = func();
            return ReferenceEquals(obj1, obj2);
        }

    }
}
