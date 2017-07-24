using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//PowerShell
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace HyperV_Shutdown.Classes
{
    public class PSCmdlets
    {
        


        /// <summary>
        /// Detects all VMs 
        /// </summary>
        public static List<VM> DiscoverVMs()
        {
            List<VM> hvList = new List<VM>();
            try
            {
                //Create PowerShell object
                PowerShell ps = PowerShell.Create();
                ps.AddCommand("Get-VM");

                int index = 0;

                foreach (PSObject result in ps.Invoke())
                {
                    VM hyperVM = new VM(index, result.Members["Name"].Value.ToString(), result.Members["State"].Value.ToString(), "");

                    index++;
                    //Add current VM to VM List
                    hvList.Add(hyperVM);
                }
                ps.Dispose();
                ps = null;
            }
            catch (Exception e)
            {
                VM hyperVMError = new VM(999, "Error", "Error", e.Message);

                hvList.Add(hyperVMError);

            }
            return hvList;
        }

        /// <summary>
        /// Turns a Hyper VM On
        /// </summary>
        public static void TurnVmOn(string vmName)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("Start-VM");
            ps.AddParameter("Name", vmName);
            ps.Invoke();
            ps.Dispose();
        }
        /// <summary>
        /// Turns a Hyper VM On
        /// </summary>
        public static void TurnVmOff(string vmName)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("Stop-VM");
            ps.AddParameter("Name", vmName);
            ps.Invoke();
            ps.Dispose();
        }
        /// <summary>
        /// Gets current state of a Hyper VM
        /// </summary>
        public static string GetVMState(string vmName)
        {
            string state = PowerShell.Create(RunspaceMode.NewRunspace).AddScript("Get-VM").AddParameter("Name", vmName).Invoke()[0].Members["State"].Value.ToString();
            return state;
        }
        /// <summary>
        /// Restarts all VMs
        /// </summary>
        /// <param name="vmList"></param>
        /// <param name="timeDelay"></param>
        public static void RestartAllVMs(List<VM> vmList, int timeDelay)
        {
           /* Thread threadedTask = new Thread(() =>
            {
                foreach (VM vm in vmList)
                {
                    TurnVmOff(vm.vmName);
                    //ISSUES IS HERE
                    while (GetVMState(vm.vmName) == "Running")
                    {
                        //DELAYS THE TURN ON COMMAND
                    }
                    Thread.Sleep(500);

                    TurnVmOn(vm.vmName);

                    //Delay Between each machines restart
                    Thread.Sleep(timeDelay * 1000);
                }
            });
            threadedTask.IsBackground = true;
            threadedTask.Start();*/
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
