using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BatchExecutionQueueSvcLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBatchExecutionQueue
    {
        [OperationContract(IsOneWay = true)]
        void ShellCommand(string command, string shell, string processName, bool admin, bool impersonate, bool loadEnvironmentVariablesFromEmacs, Guid jobGuid, string jobName, string logfile, string workingDirectory, System.Collections.Generic.Dictionary<string, string> environmentVariables);
    }
}
