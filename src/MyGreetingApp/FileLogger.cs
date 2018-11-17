namespace MyGreetingApp
{
    public class FileLogger : ILogger
    {
        private readonly Serilog.ILogger serilogLogger;

        public FileLogger(Serilog.ILogger serilogLogger)
        {
            this.serilogLogger = serilogLogger;
        }
        
        public void Info(string message)
        {
            serilogLogger.Information(message);
        }

        public void Warning(string message)
        {
            serilogLogger.Warning(message);
        }

        public void Error(string message)
        {
            serilogLogger.Error(message);
        }
    }
}
