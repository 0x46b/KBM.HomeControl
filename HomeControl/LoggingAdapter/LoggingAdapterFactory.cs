using System;
using JetBrains.Annotations;
using Ninject.Extensions.Logging;
using ServiceStack.Logging;

namespace HomeControl.LoggingAdapter
{
    [UsedImplicitly]
    class LoggingAdapterFactory : ILogFactory
    {
        private readonly ILoggerFactory _loggerFactory;

        public LoggingAdapterFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public ILog GetLogger(Type type)
        {
            return new LoggingAdapter(_loggerFactory, type);
        }

        public ILog GetLogger(string typeName)
        {
            return new LoggingAdapter(_loggerFactory, typeName);
        }
    }
}
