using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Design_Patterns.Builder.HtmlBuilderProgram.HtmlElement;

namespace Design_Patterns.Builder
{
    internal class HtmlBuilderProgram
    {
        public class HtmlElement
        {
            public string TagName;
            public string Text;
            public List<HtmlElement> Elements =  new List<HtmlElement>();
            public const int IndentSize = 2;
            public HtmlElement() { }
            public HtmlElement(string name, string text)
            {
                TagName = name;
                Text = text;
            }

            private string ToStringImpl(int indent)
            {
                StringBuilder sb = new StringBuilder();
                var i = new string(' ', IndentSize * indent);
                sb.Append($"{i}<{TagName}>\n");
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    sb.Append(new string(' ', IndentSize * (indent + 1)));
                    sb.Append(Text);
                    sb.Append("\n");
                }

                foreach (var e in Elements)
                    sb.Append(e.ToStringImpl(indent + 1));

                sb.Append($"{i}</{TagName}>\n");
                return sb.ToString();
            }

            public override string ToString()
            {
                return ToStringImpl(0);
            }

            public class HtmlBuilder
            {
                private readonly string rootName;

                public HtmlBuilder(string rootName)
                {
                    this.rootName = rootName;
                    root.TagName = rootName;
                }

                // not fluent
                public void AddChild(string childName, string childText)
                {
                    var e = new HtmlElement(childName, childText);
                    root.Elements.Add(e);
                }

                public HtmlBuilder AddChildFluent(string childName, string childText)
                {
                    var e = new HtmlElement(childName, childText);
                    root.Elements.Add(e);
                    return this;
                }

                public override string ToString()
                {
                    return root.ToString();
                }

                public void Clear()
                {
                    root = new HtmlElement { TagName = rootName };
                }

                HtmlElement root = new HtmlElement();
            }

        }

        public static void Main(string[] args)
        {
            // if you want to build a simple HTML paragraph using StringBuilder
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            // now I want an HTML list with 2 words in it
            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            // ordinary non-fluent builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());

            // fluent builder
            sb.Clear();
            builder.Clear(); // disengage builder from the object it's building, then...
            builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
            Console.WriteLine(builder);
        }
    }
}
