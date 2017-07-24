using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PowerShell
using System.Management.Automation;

namespace HyperV_Shutdown.Classes
{
    public class PowerShellCmdlets
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
            return state;
        }
        /// <summary>
        /// Restarts all VMs by specified order
        /// </summary>
        /// <param name="vmList"></param>
        /// <param name="timeDelay"></param>
        public static void RestartAllVMs(List<VM> vmList, int timeDelay)
        {
            foreach (VM vm in vmList)
            {
                TurnVmOff(vm.vmName);
                while (GetVMState(vm.vmName) == "Running")
                {
                    //DELAYS THE TURN ON COMMAND
                }
                TurnVmOn(vm.vmName);
            }
        }
    }
}
