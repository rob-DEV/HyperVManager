using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//PowerShell
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace HyperVManager.Classes
{
    public class PSCmdlets
    {
        /// <summary>
        /// Detects all VMs 
        /// </summary>
        public static List<VM> DiscoverVMs()
        {
            List<VM> hvList = new List<VM>();

            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            PowerShell ps = PowerShell.Create();
                ps.Runspace = runspace;
                ps.AddCommand("Get-VM");
                int index = 0;
                foreach(PSObject result in ps.Invoke())
                {
                    VM hyperVM = new VM(index, result.Members["Name"].Value.ToString(), result.Members["State"].Value.ToString(), "");

                    index++;
                    //Add current VM to VM List
                    hvList.Add(hyperVM);
                }
            runspace.Close();
            runspace.Dispose();
            return hvList;
        }
        /// <summary>
        /// Turns a Hyper VM On
        /// </summary>
        public static void TurnVmOn(string vmName)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            PowerShell ps = PowerShell.Create();
                ps.AddCommand("Start-VM");
                ps.AddParameter("Name", vmName);
                ps.Invoke();
            runspace.Close();
            runspace.Dispose();
        }
        /// <summary>
        /// Turns a Hyper VM On
        /// </summary>
        public static void TurnVmOff(string vmName)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            PowerShell ps = PowerShell.Create();
                ps.AddCommand("Stop-VM");
                ps.AddParameter("Name", vmName);
                ps.Invoke();
            runspace.Close();
            runspace.Dispose();
        }
        /// <summary>
        /// Gets current state of a Hyper VM
        /// </summary>
        public static string GetVMState(string vmName)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            PowerShell ps = PowerShell.Create();
                ps.AddCommand("Get-VM");
                ps.AddParameter("Name", vmName);
                string state = ps.Invoke()[0].Members["State"].Value.ToString();
            runspace.Close();
            runspace.Dispose();
            return state;

        }
        /// <summary>
        /// Restarts all VMs
        /// </summary>
        /// <param name="vmList"></param>
        /// <param name="timeDelay"></param>
        public static void RestartAllVMs(List<VM> vmList, int timeDelay)
        {
            Thread threadedTask = new Thread(() =>
            {
                foreach (VM vm in vmList)
                {
                    TurnVmOff(vm.vmName);
                    //ISSUES IS HERE
                    while (GetVMState(vm.vmName) == "Running")
                    {
                        //DELAYS THE TURN ON COMMAND
                    }
                    TurnVmOn(vm.vmName);
                    //Delay Between each machines restart
                    Thread.Sleep(timeDelay * 1000);
                }
            });
            threadedTask.IsBackground = true;
            threadedTask.Start();
        }
        /// <summary>
        /// Shuts down all VMs
        /// </summary>
        /// <param name="vmList"></param>
        /// <param name="timeDelay"></param>
        public static void ShutdownAllVMs(List<VM> vmList, int timeDelay)
        {
            Thread threadedTask = new Thread(() =>
            {
                foreach (VM vm in vmList)
                {
                    TurnVmOff(vm.vmName);
                    //Delay Between each machines shutdown
                    Thread.Sleep(timeDelay * 1000);
                }
            });
            threadedTask.IsBackground = true;
            threadedTask.Start();
        }
        /// <summary>
        /// Starts All VMs
        /// </summary>
        /// <param name="vmList"></param>
        /// <param name="timeDelay"></param>
        public static void StartAllVMs(List<VM> vmList, int timeDelay)
        {
            Thread threadedTask = new Thread(() =>
            {
                foreach (VM vm in vmList)
                {
                    TurnVmOn(vm.vmName);
                    //Delay Between each machines shutdown
                    Thread.Sleep(timeDelay * 1000);
                }
            });
            threadedTask.IsBackground = true;
            threadedTask.Start();
        }
    }
}
