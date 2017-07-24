using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//PowerShell
using System.Management.Automation;

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
            ps.AddArgument(vmName);
            ps.Invoke();
            ps.Dispose();
            ps = null;
        }
        /// <summary>
        /// Turns a Hyper VM On
        /// </summary>
        public static void TurnVmOff(string vmName)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("Stop-VM");
            ps.AddArgument(vmName);
            ps.Invoke();
            ps.Dispose();
            ps = null;
        }
        /// <summary>
        /// Gets current state of a Hyper VM
        /// </summary>
        public static string GetVMState(string vmName)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("Get-VM");
            ps.AddArgument(vmName);
            string state = ps.Invoke()[0].Members["State"].Value.ToString();
            ps.Dispose();
            ps = null;
            return state;
        }
        /// <summary>
        /// Restarts all VMs
        /// </summary>
        /// <param name="vmList"></param>
        /// <param name="timeDelay"></param>
        public static void RestartAllVMs(List<VM> vmList, int timeDelay)
        {
            Task mytask = Task.Run(() =>
            {
                foreach (VM vm in vmList)
                {
                    TurnVmOff(vm.vmName);
                    while (GetVMState(vm.vmName) == "Running")
                    {
                        //DELAYS THE TURN ON COMMAND
                    }
                    TurnVmOn(vm.vmName);

                    //Delay Between each machines restart
                    Thread.Sleep(timeDelay * 1000);
                }
            });
        }
        /// <summary>
        /// Shuts down all VMs
        /// </summary>
        /// <param name="vmList"></param>
        /// <param name="timeDelay"></param>
        public static void ShutdownAllVMs(List<VM> vmList, int timeDelay)
        {
            Task mytask = Task.Run(() =>
            {
                foreach (VM vm in vmList)
                {
                    TurnVmOff(vm.vmName);
                    //Delay Between each machines shutdown
                    Thread.Sleep(timeDelay * 1000);
                }
            });
        }
        /// <summary>
        /// Starts All VMs
        /// </summary>
        /// <param name="vmList"></param>
        /// <param name="timeDelay"></param>
        public static void StartAllVMs(List<VM> vmList, int timeDelay)
        {
            Task mytask = Task.Run(() =>
            {
                foreach (VM vm in vmList)
                {
                    TurnVmOn(vm.vmName);
                    //Delay Between each machines shutdown
                    Thread.Sleep(timeDelay * 1000);
                }
            });
        }
    }
}
