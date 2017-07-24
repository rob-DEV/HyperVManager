using System;
using System.Collections.Generic;
using System.Windows.Forms;

using HyperVManager.Classes;
namespace HyperVManager
{
    public partial class frmMain : Form
    {
        private List<VM> vmList;

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
        }
        /// <summary>
        /// Populates the listbox and add VMs to vmList
        /// </summary>
        private void PopulateListBox()
        {
            vmList = HyperVManager.Classes.PSCmdlets.DiscoverVMs();


            foreach (VM vm in vmList)
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
                    hyperVListBox.Items.Add(vm.vmName);
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
             string vmName = hyperVListBox.SelectedItem.ToString();

             //Find index of VM by name 
             int vmIndex = vmList.FindIndex(x => x.vmName.Contains(vmName));

             VM temporaryVM = vmList[vmIndex];
             vmList.RemoveAt(vmIndex);

             //New Index
             vmList.Insert(newIndex, temporaryVM);
             temporaryVM = null;

             indexer.Text = newIndex.ToString();
         }
        private void TaskManager()
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
             MessageBox.Show("Task Initiated!");
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
             TaskManager();
         }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> states = PSCmdlets.GetVMStates(vmList);
            for(int i = 0; i < vmList.Count; i++)
            {
                consoleTextBox.Text += vmList[i].vmName + " " + states[i] + "\r\n";
            }
        }
    }
}
