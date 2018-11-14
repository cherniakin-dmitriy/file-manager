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
    public partial class RequestDeleteForm : Form
    {
        public RequestDeleteForm()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            main.LeftPanel.Delete();
            Hide();
        }

        private void No_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
