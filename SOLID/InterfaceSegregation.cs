using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.SOLID
{
    
    internal class InterfaceSegregation
    {
        public interface IMachine
        {
            public void Print(Document d);
            public void Scan(Document d);
            public void Fax(Document d);
        }

        // ok if you need a multifunction machine
        public class MultiPurposePrinter : IMachine
        {
            public void Fax(Document d)
            {
                Console.WriteLine("Fax.");
            }
            public void Print(Document d)
            {
                Console.WriteLine("Print.");
            }

            public void Scan(Document d)
            {
                Console.WriteLine("Scan.");
            }
        }

        // poor idea, it only can print, other 2 methods not needed
        public class OldFashionPrinter : IMachine
        {
            void IMachine.Fax(Document d)
            {
                throw new NotImplementedException();
            }

            void IMachine.Print(Document d)
            {
                Console.WriteLine("Print.");
            }

            void IMachine.Scan(Document d)
            {
                throw new NotImplementedException();
            }
        }

        // better aproach
        public interface IPrinter
        {
            public void Print(Document d);
        }

        public interface IScanner
        {
            public void Scan(Document d);
        }

        public class PhotoCopier : IPrinter, IScanner
        {
            public void Scan(Document d)
            {
                Console.WriteLine($"Print PhotoCopier: {d}");
            }

            public void Print(Document d)
            {
                Console.WriteLine($"Scan PhotoCopier: {d}");
            }
        }

        public interface IMultiFunctionDevice : IScanner, IPrinter
        {
           
        }

        public class MultiFunctionDevice : IMultiFunctionDevice
        {
            private readonly IPrinter printer;
            private readonly IScanner scanner;

            public MultiFunctionDevice(IPrinter printer, IScanner scanner)
            {
                this.printer = printer;
                this.scanner = scanner;
            }

            public void Print(Document d)
            {
                printer.Print(d);
            }

            public void Scan(Document d)
            {
                scanner.Scan(d);
            }
        }

        public class Document
        {
        }

        public static void Main(string[] args)
        {
            var printer = new PhotoCopier();
            var mfd = new MultiFunctionDevice(printer, printer);
            mfd.Scan(new Document { });
            mfd.Print(new Document { });
        }
    }
}
