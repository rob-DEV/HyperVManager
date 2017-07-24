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

            PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(4, 0), null, null, false);
            Runspace runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance);
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
            instance.Dispose();
            return hvList;
        }
        /// <summary>
        /// Turns a Hyper VM On
        /// </summary>
        public static void TurnVmOn(string vmName)
        {
            PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(4, 0), null, null, false);
            Runspace runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance);
            runspace.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = runspace;
            ps.AddCommand("Start-VM");
            ps.AddParameter("Name", vmName);
            ps.Invoke();
            runspace.Close();
            runspace.Dispose();
            instance.Dispose();
        }
        /// <summary>
        /// Turns a Hyper VM On
        /// </summary>
        public static void TurnVmOff(string vmName)
        {
            PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(4, 0), null, null, false);
            Runspace runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance);
            runspace.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = runspace;
            ps.AddCommand("Stop-VM");
            ps.AddParameter("Name", vmName);
            ps.Invoke();
            runspace.Close();
            runspace.Dispose();
            instance.Dispose();
        }
        /// <summary>
        /// Gets current state of a Hyper VM
        /// </summary>
        public static List<string> GetVMStates(List<VM> vms)
        {
            List<string> vmStates = new List<string>();
            PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(4, 0), null, null, false);
            Runspace runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance);
            runspace.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = runspace;
            ps.AddCommand("Get-VM");
            foreach(PSObject pso in ps.Invoke())
            {
                string state = pso.Members["State"].Value.ToString();
                vmStates.Add(state);
            }
            runspace.Close();
            runspace.Dispose();
            instance.Dispose();
            GC.Collect();
            return vmStates;
        }
        /// <summary>
        /// Get current state of a Singular VM
        /// </summary>
        /// <param name="vms"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetVMStates(List<VM> vms, int index)
        {
            List<string> vmStates = new List<string>();
            PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(4, 0), null, null, false);
            Runspace runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance);
            runspace.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = runspace;
            ps.AddCommand("Get-VM");
            ps.AddParameter("Name", vms[index].vmName);
            string state = ps.Invoke()[0].Members["state"].Value.ToString();
            runspace.Close();
            runspace.Dispose();
            instance.Dispose();
            GC.Collect();
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
                for (int i = 0; i < vmList.Count; i++)
                {
                    TurnVmOff(vmList[i].vmName);
                    //ISSUES IS HERE
                    while (GetVMStates(vmList, i) == "Running")
                    {
                        
                        //DELAYS THE TURN ON COMMAND
                    }
                    TurnVmOn(vmList[i].vmName);
                    //Delay Between each machines restart
                    Thread.Sleep(timeDelay * 1000);
                }
                GC.Collect();
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
                GC.Collect();
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
                GC.Collect();
            });
            threadedTask.IsBackground = true;
            threadedTask.Start();
        }
    }
}
