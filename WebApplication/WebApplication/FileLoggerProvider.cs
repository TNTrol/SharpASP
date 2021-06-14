using Microsoft.Extensions.Logging;

namespace WebApplication
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _filepath;

        public FileLoggerProvider(string filepath)
        {
            _filepath = filepath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_filepath);
        }

        public void Dispose()
        {
        }
    }
}