using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HyperV_Shutdown.Classes;
namespace HyperV_Shutdown
{
    public partial class frmMain : Form
    {
        private List<VM> vmList = new List<VM>();

        string[] vmTasksOptions = new string[] { "Restart", "Shutdown","Start"};

        public frmMain()
        {
            InitializeComponent();
            this.CenterToScreen();
            //Set Button Arrow
            reorderUpButton.Text = char.ConvertFromUtf32(8593);
            reorderDownButton.Text = char.ConvertFromUtf32(8595);

            //Sets up the GUI
            PopulateListBox();

            //Task selection
            vmOptionDropDown.Items.AddRange(vmTasksOptions);
            vmOptionDropDown.SelectedItem = vmOptionDropDown.Items[0];

            //Update Timer
            //InitTimer();
        }
        /// <summary>
        /// Populates the listbox and add VMs to vmList
        /// </summary>
        private void PopulateListBox()
        {
            vmList = HyperV_Shutdown.Classes.PSCmdlets.DiscoverVMs();
            foreach(VM vm in vmList)
            {
                //Check for error - Hyper V not installed
                if (vm.vmError != "")
                {
                    //Error Exists
                    MessageBox.Show(string.Format("{0} - Hyper-V is not installed on this machine", vm.vmError));
                    vmList.RemoveAt(0);
                    break;
                }
                else
                {
                    hyperVListBox.Items.Add(vm.vmName + " ");
                }
            }
        }
        /// <summary>
        /// Reorder the VM in the listbox
        /// </summary>
        /// <param name="direction"></param>
        private void MoveItem(int direction)
        {
            // Checking selected item
            if (hyperVListBox.SelectedItem == null || hyperVListBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = hyperVListBox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= hyperVListBox.Items.Count)
                return; // Index out of range - nothing to do

            object selected = hyperVListBox.SelectedItem;

            // Removing removable element
            hyperVListBox.Items.Remove(selected);
            // Insert it in new position
            hyperVListBox.Items.Insert(newIndex, selected);
            // Restore selection
            hyperVListBox.SetSelected(newIndex, true);

            //REORDER the vmList from the GUI
            //Get VM NAME
            string vmString = hyperVListBox.SelectedItem.ToString();
            string vmName = vmString.Split(' ')[0];

            //Find index of VM by name 
            int vmIndex = vmList.FindIndex(x => x.vmName.Contains(vmName));

            VM temporaryVM = vmList[vmIndex];
            vmList.RemoveAt(vmIndex);

            //New Index
            vmList.Insert(newIndex, temporaryVM);
            temporaryVM = null;
        }
        /// <summary>
        /// Refreshes the states of each VM
        /// </summary>
        private void RefreshVMStates()
        {
            hyperVListBox.Items.Clear();
            foreach (VM vm in vmList)
            {
                hyperVListBox.Items.Add(vm.vmName + "------" + PSCmdlets.GetVMState(vm.vmName));
            }
        }
        private void statusUpdaterTimer_Tick(object sender, EventArgs e)
        {
            RefreshVMStates();
        }

        //USER INTERACTION

        //Tools Strip
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XML.SaveVMConfig(vmList);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Tools Strip End
        private void reorderUpButton_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }
        private void reorderDownButton_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }
        private void setTaskButton_Click(object sender, EventArgs e)
        {
            int delayTime;
            delayTime = Convert.ToInt32(restartTimeTexbox.Text);
            switch (vmOptionDropDown.SelectedItem.ToString())
            {
                case "Restart":
                    PSCmdlets.RestartAllVMs(vmList, delayTime);
                    break;
                case "Shutdown":
                    PSCmdlets.ShutdownAllVMs(vmList, delayTime);
                    break;
                case "Start":
                    PSCmdlets.StartAllVMs(vmList, delayTime);
                    break;
                default:
                    MessageBox.Show("Unknown case parameter");
                    break;
            } 

            
        }
    }
}
