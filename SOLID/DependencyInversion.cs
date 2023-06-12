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

        // Business Logic Layer
        public interface IOrderProcessor
        {
            void ProcessOrder(Order order);
        }

        public class OrderProcessor : IOrderProcessor
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IEmailService _emailService;

            public OrderProcessor(IOrderRepository orderRepository, IEmailService emailService)
            {
                _orderRepository = orderRepository;
                _emailService = emailService;
            }

            public void ProcessOrder(Order order)
            {
                _orderRepository.SaveOrder(order);
                _emailService.SendEmail(order.CustomerEmail, "Order processed successfully");
            }
        }

        // Data Access Layer
        public interface IOrderRepository
        {
            void SaveOrder(Order order);
        }

        public class DatabaseOrderRepository : IOrderRepository
        {
            public void SaveOrder(Order order)
            {
                // Implementation for saving order to a database
            }
        }

        // Service Layer
        public interface IEmailService
        {
            void SendEmail(string recipient, string message);
        }

        public class SmtpEmailService : IEmailService
        {
            public void SendEmail(string recipient, string message)
            {
                // Implementation for sending an email using SMTP
            }
        }

        public class Order
        {
            public string CustomerEmail { get; set;}
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
