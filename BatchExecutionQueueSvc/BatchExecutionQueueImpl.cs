using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BatchExecutionQueueSvcLib
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerSession/*InstanceContextMode.Single*/
    )]
    public class BatchExecutionQueueImpl : IBatchExecutionQueue
    {
        public void ShellCommand(string command, string shell, string processName, bool admin, bool impersonate, bool loadEnvironmentVariablesFromEmacs, Guid jobGuid, string jobName, string logfile, string workingDirectory, Dictionary<string, string> environmentVariables)
        {
            throw new NotImplementedException();
        }
    }
}
