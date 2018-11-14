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
    public partial class Editor : Form
    {
        FileInfo file;

        public Editor(FileInfo f)
        {
            InitializeComponent();
            file = f;
            setText(File.ReadAllText(file.FullName));
        }

        public void setText(string s)
        {
            textBox1.Text = s;
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void SaveTXT()
        {
            File.WriteAllText(file.FullName, textBox1.Text);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveTXT();
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(textBox2.Text, textBox3.Text);
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseReq req = new CloseReq("editor");
            //req.Close();
            req.Owner = this;
            req.ShowDialog();
        }

        /*private void Unique_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            SortedDictionary<string, int> cnt = new SortedDictionary<string, int>();
            string cur = "";
            foreach (char ch in s)
            {
                if (ch == ' ')
                {
                    cnt[cur]++;
                    cur = "";
                }
                else
                    cur += ch;
            }
            foreach(KeyValuePair<string, int> val in cnt)
            {

            }
        }*/
    }
}
