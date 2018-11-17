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
            var greetingService = new DefaultGreetingService(new SystemClock());
            Console.WriteLine(greetingService.Greet(name));
            Console.ReadLine();
        }
    }
}
