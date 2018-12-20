using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BatchExecutionQueueSvcLib
{
    [ServiceContract(SessionMode = SessionMode.Required
    , CallbackContract = typeof(IJobControlCallback)
     )]
    public interface IJobControl
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Join(string name, string process, string eventType);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Leave(string process, string eventType);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Kill(Job job);
    }
    [DataContract]
    public class PLATFORM
    {
        public enum GIT_CLONE { Red, Blue, Green, Yellow }
        public enum OS { Desktop }
        public enum ARCHITECTURE { AMD64Fre, x86Fre, ARMFre, ARM64Fre }
        [DataMember]
        public OS Os { get; set; } = OS.Desktop;
        [DataMember]
        public ARCHITECTURE Architecture { get; set; } = ARCHITECTURE.AMD64Fre;
        [DataMember]
        public GIT_CLONE gitClone { get; set; } = GIT_CLONE.Red;
    }
    [DataContract]
    public class PROCESS
    {
       [DataMember]
        public Dictionary<string, string> environmentVars { get; set; } = new Dictionary<string, string>();
       [DataMember]
        public string defaultDirectory { get; set; }
        [DataMember]
        public bool Ephemeral { get; set; } = false;
        [DataMember]
        public PLATFORM Platform { get; set; } 
        [DataMember]
        public string CommandLineInterpreter { get; set; } = "cmd.exe";
    }
    [DataContract]
    public class Job
    {
        [DataMember]
        public string defaultDirectory { get; set; }
        [DataMember]
        public string Command { get; set; } = "";
        [DataMember]
        public PROCESS Process { get; set; }
        [DataMember]
        public Guid guid { get; set; }
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime PutInQueue { get; set; }
        [DataMember]
        public DateTime StartExecution { get; set; }
        [DataMember]
        public DateTime CompleteExecution { get; set; }
        [DataMember]
        public int CompletionCode { get; set; }
        [DataMember]
        public Int64 PID { get; set; }

    }
    [ServiceContract]
    public interface IJobControlCallback
    {
        [OperationContract(IsOneWay = true)]
        void JobStarting(Job job);
        [OperationContract(IsOneWay = true)]
        void JobComplete(Job job);
    }
}
