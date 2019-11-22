using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.CrossCuttingConcerns.Logging.log4net
{
    public class FileLogger:LoggerService
    {
        public FileLogger():base(LogManager.GetLogger("JsonFileLogger"))
        {

        }
    }
}
