using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management.Automation;

namespace HyperVPowershellTest
{
    class Program
    {
        private static string GetState(string vmName)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("Get-VM");
            ps.AddParameter("Name", vmName);
            return ps.Invoke()[0].Members["State"].Value.ToString();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press any key to get vm state \n");
                Console.ReadKey();
                Console.WriteLine(GetState("WIN-10-CL1") + "\r\n");
            }
        }
    }
}
