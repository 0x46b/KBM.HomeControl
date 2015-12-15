using System;
using System.Text;
using JetBrains.Annotations;
using Serilog;
using ServiceStack.Logging;

namespace HomeControl.LoggingAdapter
{
    [UsedImplicitly]
    class SeriLogAdapter : ILog
    {
        private readonly ILogger _logger;

        public SeriLogAdapter(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsDebugEnabled => true;

        public void Debug(object message)
        {
            _logger.Debug(message.ToString());
        }

        public void Debug(object message, Exception exception)
        {
            _logger.Debug(message.ToString(), GetFormattedException(exception));
        }

        private string GetFormattedException(Exception exception)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Exceptiontype: {exception.GetType()}");
            stringBuilder.AppendLine($"Message: {exception.Message}");
            return stringBuilder.ToString();
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
            _logger.Error(message.ToString(), GetFormattedException(exception));
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
            _logger.Fatal(message.ToString(), GetFormattedException(exception));
        }

        public void FatalFormat(string format, params object[] args)
        {
            _logger.Fatal(format, args);
        }

        public void Info(object message)
        {
            _logger.Information(message.ToString());
        }

        public void Info(object message, Exception exception)
        {
            _logger.Information(message.ToString(), GetFormattedException(exception));
        }

        public void InfoFormat(string format, params object[] args)
        {
            _logger.Information(format, args);
        }

        public void Warn(object message)
        {
            _logger.Warning(message.ToString());
        }

        public void Warn(object message, Exception exception)
        {
            _logger.Warning(message.ToString(), GetFormattedException(exception));
        }

        public void WarnFormat(string format, params object[] args)
        {
            _logger.Warning(format, args);
        }
    }
}