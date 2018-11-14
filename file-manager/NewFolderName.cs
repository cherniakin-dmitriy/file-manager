using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class NewFolderName : Form
    {

        public NewFolderName()
        {
            InitializeComponent();
        }

        private void NewNameOK_Click(object sender, EventArgs e)
        {
            string name = ReadNewName.Text;
            MainForm main = this.Owner as MainForm;
            main.LeftPanel.CreateFolder(name);  
            Hide();
        }
    }
}
