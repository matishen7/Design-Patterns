using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.SOLID
{
    internal class DependencyInversion
    {
        public interface ILogger
        {
            void Log(string message);
        }

        public class FileLogger : ILogger
        {
            private string filename;

            public FileLogger(string filename)
            {
                this.filename = filename;
            }

            public void Log(string message)
            {
                File.WriteAllText(filename, message);
            }
        }

        public class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class LogManager
        {
            private ILogger _logger;
            public LogManager(ILogger logger)
            {
                _logger = logger;
            }

            public void Log(string message)
            {
                _logger.Log(message);
            }
        }

        public static void Main(string[] args)
        {
            var filename = @"c:\\temp\\journal.txt";
            var lm = new LogManager(new ConsoleLogger());
            var lm2 = new LogManager(new FileLogger(filename));
            lm.Log("This is a log.");
            lm2.Log("This is a log");

            var psi = new ProcessStartInfo(filename)
            {
                UseShellExecute = true
            };

            Process.Start(psi);
        }
    }
}
