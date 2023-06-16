using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Design_Patterns.Builder
{
    /// <summary>
    /// Step wise builder
    /// </summary>
    internal class DocumentBuilderProgram
    {
        class Document
        {
            public string? Title { get; set; }
            public string? Content { get; set; }
            public DateTime CreatedDate { get; set; }
            public string?  Author { get; set; }

            public override string ToString()
            {
                return $"{nameof(Title)}: {Title}, {nameof(Content)}: {Content}, {nameof(CreatedDate)}: {CreatedDate}, {nameof(Author)}: {Author}";
            }
        }
    }
}
