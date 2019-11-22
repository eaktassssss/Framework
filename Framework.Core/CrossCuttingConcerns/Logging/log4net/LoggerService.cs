using log4net;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.CrossCuttingConcerns.Logging.log4net
{
    [Serializable]
    public class LoggerService
    {
        private readonly ILog _log;
        public LoggerService(ILog log)
        {
            _log = log;
        }


        public bool IsInfoEnabled
        {
            get
            {
                return _log.IsInfoEnabled;
            }
        }

        public bool IsDebugEnabled
        {
            get
            {
                return _log.IsDebugEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return _log.IsFatalEnabled;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return _log.IsErrorEnabled;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return _log.IsWarnEnabled;
            }
        }

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logMessage);
            }
        }


        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(logMessage);
            }
        }


        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logMessage);
            }
        }


        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMessage);
            }
        }


        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMessage);
            }
        }
    }


    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _logginEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _logginEvent = loggingEvent;
        }
        public string UserName
        {
            get { return _logginEvent.UserName; }
        }
        public object ObjectMessage
        {
            get { return _logginEvent.MessageObject; }
        }
    }


    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            return;
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);
            writer.WriteLine(json);
        }
    }
}
