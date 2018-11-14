using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETable;

namespace Manager
{
    public partial class CloseReq : Form
    {
        string editorType;

        public CloseReq(string type)
        {
            editorType = type;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (editorType == "editor")
            {
                Editor editor = Owner as Editor;
                editor.SaveTXT();
            }
            else
            {
                eTable editor = Owner as eTable;
                editor.Save();   
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
