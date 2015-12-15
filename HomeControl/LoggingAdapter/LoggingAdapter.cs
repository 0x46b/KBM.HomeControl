using System;
using JetBrains.Annotations;
using Ninject.Extensions.Logging;
using ServiceStack.Logging;

namespace HomeControl.LoggingAdapter
{
    [UsedImplicitly]
    class LoggingAdapter : ILog
    {
        private readonly ILogger _logger;

        public LoggingAdapter(ILoggerFactory loggerFactory, Type type)
        {
            _logger = loggerFactory.GetLogger(type);
        }

        public LoggingAdapter(ILoggerFactory loggerFactory, string typeName)
        {
            _logger = loggerFactory.GetLogger(typeName);
        }

        public bool IsDebugEnabled => true;

        public void Debug(object message)
        {
            _logger.Debug(message.ToString());
        }

        public void Debug(object message, Exception exception)
        {
            _logger.DebugException(message.ToString(), exception);
        }
        
        public void DebugFormat(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Error(object message)
        {
            _logger.Error(message.ToString());
        }

        public void Error(object message, Exception exception)
        {
            _logger.ErrorException(message.ToString(), exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _logger.Error(format, args);
        }

        public void Fatal(object message)
        {
            _logger.Fatal(message.ToString());
        }

        public void Fatal(object message, Exception exception)
        {
            _logger.FatalException(message.ToString(), exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _logger.Fatal(format, args);
        }

        public void Info(object message)
        {
            _logger.Info(message.ToString());
        }

        public void Info(object message, Exception exception)
        {
            _logger.InfoException(message.ToString(), exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _logger.Info(format, args);
        }

        public void Warn(object message)
        {
            _logger.Warn(message.ToString());
        }

        public void Warn(object message, Exception exception)
        {
            _logger.WarnException(message.ToString(), exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _logger.Warn(format, args);
        }
    }
}