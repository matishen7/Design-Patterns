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
    public class CodeBuilderExercise
    {
        public class Code
        {
            public Code() { }
            public string ClassName { get; set; }
            public Dictionary<string, string> Properties = new Dictionary<string, string>();

            public override string ToString()
            {
                var display = new StringBuilder();

                display.Append("public class " + ClassName + "\n");
                display.Append("{\n");
                foreach (var key in Properties.Keys)
                {
                    var value = Properties[key];
                    display.Append($"  public {key} {value};\n");
                }
                display.Append("}");

                return display.ToString();
            }
        }

        public class CodeBuilder
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
            Console.WriteLine(cb);
        }

    }
}
