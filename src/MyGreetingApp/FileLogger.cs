using System.Reflection;
using log4net;
using static log4net.LogManager;

namespace MyGreetingApp
{
    public class FileLogger : ILogger
    {
        private static readonly ILog log = GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Warning(string message)
        {
            log.Warn(message);
        }
    }
}
