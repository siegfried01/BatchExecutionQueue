using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BatchExecutionQueueSvcLib
{
    [ServiceContract(SessionMode = SessionMode.Required
    , CallbackContract = typeof(IProcessControlCallback)
     )]
    public interface IProcessControl
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void CreateProcess(PROCESS proces);
    }
    public interface IProcessControlCallback
    {

    }
}
