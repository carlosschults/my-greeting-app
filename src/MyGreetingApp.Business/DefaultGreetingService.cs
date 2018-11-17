using System;

namespace MyGreetingApp.Business
{
    public class DefaultGreetingService : IGreetingService
    {
        private readonly IClock clock;

        public DefaultGreetingService(IClock clock)
        {
            this.clock = clock ?? throw new ArgumentNullException();
        }

        public string Greet(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                var msg = $"{nameof(userName)} should be a valid, non-empty string!";
                throw new ArgumentException(msg);
            }

            var currentTime = clock.Now().TimeOfDay;
            var greeting = string.Empty;

            if (currentTime >= TimeSpan.FromHours(6) && currentTime < TimeSpan.FromHours(12))
            {
                greeting = "Good morning";
            }
            else if (currentTime >= TimeSpan.FromHours(12) && currentTime < TimeSpan.FromHours(19))
            {
                greeting = "Good afternoon";
            }
            else
            {
                greeting = "Good evening";
            }

            return $"{greeting}, {userName}!";
        }
    }
}
