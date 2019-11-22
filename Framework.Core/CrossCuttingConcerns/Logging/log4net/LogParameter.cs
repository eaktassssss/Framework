using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.CrossCuttingConcerns.Logging.log4net
{
    /// <summary>
    /// Log parametrelerine ait  Name, Type, Value değerlerini tutar
    /// </summary>
    public class LogParameter
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
    }
    /// <summary>
    ///  Sırası ile Namespace,Method ismi,Log parametrelerini tutar
    /// </summary>
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> Parameters { get; set; }
    }
}
