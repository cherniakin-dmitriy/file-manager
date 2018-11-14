using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Manager
{
    public partial class MainForm : Form
    {
        public NewFolderName newFolderName;
        public NewFileName newFileName;
        public RequestDeleteForm newReqDelete;
        public Rename newRename;
        public Panel RightPanel;
        public Panel LeftPanel;
        public MainForm()
        {
            InitializeComponent();
            RightPanel = new Panel(RightList, RightCBox, RightLabel, imageList);
            LeftPanel = new Panel(LeftList, LeftCBox, LeftLabel, imageList);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RightCBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DriveInfo drive = new DriveInfo(RightCBox.SelectedItem.ToString());
            RightPanel.ChangeDrive(drive);
        }

        private void LeftCBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DriveInfo drive = new DriveInfo(LeftCBox.SelectedItem.ToString());
            CreateFolderButton.Enabled = true;
            NewXML.Enabled = true;
            NewFile.Enabled = true;
            LeftPanel.ChangeDrive(drive);
        }

        private void LeftList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LeftPanel.Open(LeftList.SelectedItems[0]);
        }

        private void файлToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void LeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            newReqDelete = new RequestDeleteForm();
            newReqDelete.Owner = this;
            newReqDelete.Show();
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            newRename = new Rename();
            newRename.Owner = this;
            newRename.Show();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            LeftPanel.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            LeftPanel.Paste();
        }

        private void NewFile_Click(object sender, EventArgs e)
        {
            newFileName = new NewFileName(".txt");
            newFileName.Owner = this;
            newFileName.Show();
        }

        private void NewFolderName_Click(object sender, EventArgs e)
        {
            newFolderName = new NewFolderName();
            newFolderName.Owner = this;
            newFolderName.Show();
        }

        private void LeftList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RightList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RightPanel.Open(RightList.SelectedItems[0]);
        }

        private void RightLabel_Click(object sender, EventArgs e)
        {

        }

        private void SuperPaste_Click(object sender, EventArgs e)
        {
            LeftPanel.SuperPaste();
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            LeftPanel.Filter(FilterBox.Text);
        }

        private void NewXML_Click(object sender, EventArgs e)
        {
            newFileName = new NewFileName(".xml");
            newFileName.Owner = this;
            newFileName.Show();
        }

        private void LeftCBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}