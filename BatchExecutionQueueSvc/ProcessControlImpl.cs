using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BatchExecutionQueueSvcLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    class ProcessControlImpl : IProcessControl
    {
        public static Dictionary<string,Process> processes = new Dictionary<string,Process>();
        public void CreateProcess(PROCESS processSpecifications)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(processSpecifications.CommandLineInterpreter);
            startInfo.CreateNoWindow = true;
            startInfo.ErrorDialog = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            processes[processSpecifications.Platform.ToString()] = process;
            process.StartInfo = startInfo;
            process.Start();
            Read(process.StandardOutput);
            Read(process.StandardError);
            new Thread(() =>
            {
                while (true)
                    process.StandardInput.WriteLine(Console.ReadLine());
            }).Start();
        }
        private static void Read(StreamReader reader)
        {
            new Thread(() =>
            {
                while (true)
                {
                    int current;
                    while ((current = reader.Read()) >= 0)
                        Console.Write((char)current);
                }
            }).Start();
        }

    }
}
