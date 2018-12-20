using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchExecutionQueueSvcLib
{
    class JobControlImpl : IJobControl
    {
        public void Join(string name, string process, string eventType)
        {
            throw new NotImplementedException();
        }

        public void Kill(Job job)
        {
            throw new NotImplementedException();
        }

        public void Leave(string process, string eventType)
        {
            throw new NotImplementedException();
        }
    }
}
