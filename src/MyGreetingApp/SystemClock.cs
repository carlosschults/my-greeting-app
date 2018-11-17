using System;
using MyGreetingApp.Business;

namespace MyGreetingApp
{
    public class SystemClock : IClock
    {
        public DateTimeOffset Now() => DateTimeOffset.Now;
    }
}
