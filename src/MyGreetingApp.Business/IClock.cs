using System;

namespace MyGreetingApp.Business
{
    interface IClock
    {
        DateTimeOffset Now();
    }
}
