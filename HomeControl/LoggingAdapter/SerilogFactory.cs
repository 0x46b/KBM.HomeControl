using System;
using ServiceStack.Logging;

namespace HomeControl.LoggingAdapter
{
    class SerilogFactory : ILogFactory
    {
        private readonly ILog _logger;

        public SerilogFactory(ILog logger)
        {
            _logger = logger;
        }

        public ILog GetLogger(Type type)
        {
            return _logger;
        }

        public ILog GetLogger(string typeName)
        {
            return _logger;
        }
    }
}
