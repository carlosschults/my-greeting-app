using MyGreetingApp.Business;
using Serilog;
using System;

namespace MyGreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please inform your name: ");
            var name = Console.ReadLine();

            using (var log = new LoggerConfiguration()
            .WriteTo.File(@"serilog-example.log")
            .CreateLogger())
            {
                var greetingService = new LoggingGreetingService(
                    new DefaultGreetingService(new SystemClock()),
                    new FileLogger(log));

                Console.WriteLine(greetingService.Greet(name));
            }

            Console.ReadLine();
        }
    }
}
