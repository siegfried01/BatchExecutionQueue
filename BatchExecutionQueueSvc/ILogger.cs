using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BatchExecutionQueueSvcLib
{
    [ServiceContract(SessionMode = SessionMode.Required
    , CallbackContract = typeof(ILoggerCallback)
     )]
    public interface ILogger
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Join(string name, string process, string eventType);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Leave(string process, string eventType);
    }
    interface ILoggerCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendLog(string process, string eventType, string text);
    }
}
