using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BatchExecutionQueueSvcLib
{
    class LoggerImpl : ILogger
    {
        public string name { get; set; } = "";
        public static CommonLib.Dictionary<string, CommonLib.Dictionary<string, System.Collections.Generic.Dictionary<string, ILoggerCallback>>> Loggers = new CommonLib.Dictionary<string, CommonLib.Dictionary<string, System.Collections.Generic.Dictionary<string, ILoggerCallback>>>();

        public void Join(string name, string process, string eventType)
        {
            this.name = name;
            var ctx = OperationContext.Current.GetCallbackChannel<ILoggerCallback>();
            Loggers[process][eventType][name] = ctx;
        }

        public void Leave(string process, string eventType)
        {
            if(Loggers.ContainsKey(process) && Loggers[process].ContainsKey(eventType) && Loggers[process][eventType].ContainsKey(name))
            {
                Loggers[process][eventType].Remove(name);
            }
        }
    }
}
