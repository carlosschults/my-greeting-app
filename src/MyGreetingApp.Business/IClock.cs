using System;

namespace MyGreetingApp.Business
{
    public interface IClock
    {
        DateTimeOffset Now();
    }
}
