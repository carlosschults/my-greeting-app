using System;
using MyGreetingApp.Business;

namespace MyGreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please inform your name: ");
            var name = Console.ReadLine();
            var greetingService = new LoggingGreetingService(
                new DefaultGreetingService(new SystemClock()), new FileLogger());
            Console.WriteLine(greetingService.Greet(name));
            Console.ReadLine();
        }
    }
}
