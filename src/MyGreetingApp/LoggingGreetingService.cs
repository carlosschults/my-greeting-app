using System;
using MyGreetingApp.Business;

namespace MyGreetingApp
{
    public class LoggingGreetingService : IGreetingService
    {
        private readonly IGreetingService innerService;
        private readonly ILogger logger;

        public LoggingGreetingService(IGreetingService innerService, ILogger logger)
        {
            this.innerService = innerService ?? throw new ArgumentNullException(nameof(innerService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string Greet(string userName)
        {
            logger.Info($"Attempting to greet user {userName}");
            var result = innerService.Greet(userName);
            logger.Info($"Successfully generated greeting to user {userName}");
            return result;
        }
    }
}
