using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperV_Shutdown.Classes
{
    /// <summary>
    /// Creates a Hyper V object for exporting later
    /// </summary>
    [Serializable]
    public class VM
    {
        public int vmIndex;
        public string vmName;
        public string vmState;

        //Error Handling
        public string vmError = "";

        public VM()
        {
            //FOR XML
        }
        public VM(int index, string name, string state, string error)
        {
            vmIndex = index;
            vmName = name;
            vmState = state;
            vmError = error;
        }
    }
}
