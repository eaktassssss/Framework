using Framework.Core.CrossCuttingConcerns.Logging.log4net;
using PostSharp.Aspects;
using System;
using System.Reflection;

namespace Framework.Core.Aspects.Postsharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionAspect: OnExceptionAspect
    {

        Type _loggerType;
        LoggerService _loggerService;
        public ExceptionAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if(_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if(_loggerService != null)
            {
                _loggerService.Error((args.Exception));
            }
        }
    }
}
