using Serilog;
using System.IO;

namespace Excel.WebApi.Common
{
    public sealed class Log: ILog
    {
        private readonly ILogger _logger;

        public Log()
        {
            var path = (new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory).Directory.Parent.FullName);            

            _logger = new LoggerConfiguration()
                          .WriteTo.File($"{path}/Logs/log.txt", rollingInterval: RollingInterval.Day)
                          .CreateLogger();
        }
        
        public void LogError(string error)
        {
            _logger.Error(error);
        }

        public void LogInformation(string information)
        {
            _logger.Information(information);            
        }

    }
}