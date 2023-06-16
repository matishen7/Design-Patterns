using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Design_Patterns.Builder.DocumentBuilderProgram;
using Document = Design_Patterns.Builder.DocumentBuilderProgram.Document;

namespace Design_Patterns.Builder
{
    /// <summary>
    /// Step wise builder
    /// </summary>
    internal class DocumentBuilderProgram
    {
        public class Document
        {
            public string? Title { get; set; }
            public string? Content { get; set; }
            public DateTime CreatedDate { get; set; }
            public string? Author { get; set; }

            public override string ToString()
            {
                return $"{nameof(Title)}: {Title}, {nameof(Content)}: {Content}, {nameof(CreatedDate)}: {CreatedDate}, {nameof(Author)}: {Author}";
            }
        }

        public interface ISetTitle
        {
            public ISetContent SetTitle(string title);
        }

        public interface ISetContent
        {
            public IBuild SetContent(string content);
        }

        public interface IBuild
        {
            public Document Build();
        }

        public class DocumentBuilder
        {
            public static ISetTitle Create()
            {
                return new Impl();
            }
        }

        private class Impl : ISetTitle, ISetContent, IBuild
        {
            private Document d = new Document();

            public ISetContent SetTitle(string title)
            {
                d.Title = title;
                return this;
            }

            public IBuild SetContent(string content)
            {
                d.Content = content;
                return this;
            }

            public Document Build()
            {
                return d;
            }
        }

        public static void Main(string[] args)
        {
            var d = DocumentBuilder.Create()
                .SetTitle("D1")
                .SetContent("asjkhh")
                .Build();
            
            Console.Write(d.ToString());
        }
    }


}
