using Microsoft.Extensions.Logging;

namespace WebApplication
{

    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filepath)
        {
            factory.AddProvider(new FileLoggerProvider(filepath));
            return factory;
        }
    }
}