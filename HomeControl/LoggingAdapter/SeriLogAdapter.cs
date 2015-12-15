using System;
using Serilog;
using ServiceStack.Logging;

namespace HomeControl.LoggingAdapter
{
    class SeriLogAdapter : ILog
    {
        private readonly ILogger _logger;

        public SeriLogAdapter(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsDebugEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Debug(object message)
        {
            _logger.Debug(message.ToString());
        }

        public void Debug(object message, Exception exception)
        {
            _logger.Debug(message.ToString());
        }

        public void DebugFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(object message)
        {
            _logger.Error(message.ToString());
        }

        public void Error(object message, Exception exception)
        {
            _logger.Error(message.ToString());
        }

        public void ErrorFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(object message)
        {
            _logger.Fatal(message.ToString());
        }

        public void Fatal(object message, Exception exception)
        {
            _logger.Fatal(message.ToString());
        }

        public void FatalFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(object message)
        {
            _logger.Information(message.ToString());
        }

        public void Info(object message, Exception exception)
        {
            _logger.Information(message.ToString());
        }

        public void InfoFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(object message)
        {
            _logger.Warning(message.ToString());
        }

        public void Warn(object message, Exception exception)
        {
            _logger.Warning(message.ToString());
        }

        public void WarnFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}