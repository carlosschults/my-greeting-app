using NLog;

namespace MyGreetingApp
{
    public class FileLogger : ILogger
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
