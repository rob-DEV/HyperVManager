﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace HyperVManager.Classes
{
    public class XML
    {
        /// <summary>
        /// Saves the order of the VM listbox to a cfg file
        /// </summary>
        public static void SaveVMConfig(List<VM> vmList)
        {
            if (vmList.Count > 0)
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<VM>));
                TextWriter tw = new StreamWriter(@"Virtual Machines.xml");
                xs.Serialize(tw, vmList);
                tw.Close();
                tw = null;
            }
        }
    }
}
