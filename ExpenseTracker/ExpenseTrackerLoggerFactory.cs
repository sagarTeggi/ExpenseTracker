using System.Collections.Concurrent;

namespace ExpenseTracker
{
    public static class ExpenseTrackerLoggerFactory
    {
        private static ILoggerFactory _loggerFactory;
        private static ConcurrentDictionary<Type, ILogger> loggerByType = new();

        public static void Initialize(ILoggerFactory loggerFactory)
        {
            if (_loggerFactory is not null)
            {
                throw new InvalidOperationException("Logger already initialized!");
            }

            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public static ILogger GetStaticLogger<T>() 
        { 
            if(_loggerFactory is null)
                throw new InvalidOperationException("Logger not yet initialized!");


            return loggerByType.GetOrAdd(typeof(T), _loggerFactory.CreateLogger<T>());
        }

    }
}
