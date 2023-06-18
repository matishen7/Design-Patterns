using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Design_Patterns.Builder.DocumentBuilderProgram;
using static Design_Patterns.Builder.FunctionalBuilderProgram;

namespace Design_Patterns.Builder
{
    internal class CodeBuilderExercise
    {
        class Code
        {
            public Code() { }
            public string ClassName { get; set; }
            public Dictionary<string, string> Properties = new Dictionary<string, string>();

            public override string ToString()
            {
                var display = new StringBuilder();
                return display.ToString();
            }
        }

        class CodeBuilder
        {
            protected Code code;
            public CodeBuilder(string className)
            {
                code = new Code();
                code.ClassName = className;
            }

            public CodeBuilder AddField(string propertyName, string dataType)
            {
                code.Properties.Add(dataType, propertyName);
                return this;
            }

            public Code Build()
            {
                return code;
            }
        }

        public static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int")
                .Build();
            Console.WriteLine(cb.ToString());
        }

    }
}
