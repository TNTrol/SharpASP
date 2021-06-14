using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace WebApplication
{
    public class FileLogger : ILogger
    {
        private readonly string _filepath;
        private static object _lock = new object();
        public FileLogger(string path)
        {
            _filepath = path;
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(_filepath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}