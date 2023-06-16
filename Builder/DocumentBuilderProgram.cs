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
                return $"{nameof(Title)}: {Title}, " +
                    $"{nameof(Content)}: {Content}, " +
                    $"{nameof(CreatedDate)}: {CreatedDate}," +
                    $"{nameof(Author)}: {Author}";
            }
        }

        public interface ISetTitle
        {
            public ISetContent SetTitle(string title);
        }

        public interface ISetContent
        {
            public IAuthor SetContent(string content);
        }

        public interface IAuthor
        {
            public IBuild SetAuthor(string author);
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

        private class Impl : ISetTitle, ISetContent, IAuthor, IBuild
        {
            private Document d = new Document();

            public ISetContent SetTitle(string title)
            {
                d.Title = title;
                return this;
            }

            public IAuthor SetContent(string content)
            {
                d.Content = content;
                return this;
            }

            public IBuild SetAuthor(string author)
            {
                d.Author = author;
                return this;
            }

            public Document Build()
            {
                d.CreatedDate = DateTime.Now;
                return d;
            }
        }

        public static void Main(string[] args)
        {
            var d = DocumentBuilder.Create()
                .SetTitle("D1")
                .SetContent("asjkhh")
                .SetAuthor("Murat")
                .Build();
            
            Console.Write(d.ToString());
        }
    }


}
