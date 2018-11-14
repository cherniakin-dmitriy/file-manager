using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manager;

namespace ETable
{
    public partial class eTable : Form
    {
        SortedSet<char> validSymbs = new SortedSet<char>();
        Dictionary<int, int> prior = new Dictionary<int, int>();
        const int sz = 50;
        string[,] Table = new string[sz, sz];
        string path;
        DataSet ds;
        Graph refs = new Graph(sz * sz);

        public eTable(string p = "D:/dataset.xml")
        {
            InitializeComponent();
            path = p;
            char[] c = { '(', ')', '+', '-', '/', '*', ',', '>', '<', '=' };
            prior.Add(Parsing.getHash("("), 0);
            prior.Add(Parsing.getHash("<"), 1);
            prior.Add(Parsing.getHash(">"), 1);
            prior.Add(Parsing.getHash("<="), 1);
            prior.Add(Parsing.getHash(">="), 1);
            prior.Add(Parsing.getHash("<>"), 1);
            prior.Add(Parsing.getHash("="), 1);
            prior.Add(Parsing.getHash("+"), 2);
            prior.Add(Parsing.getHash("-"), 2);
            prior.Add(Parsing.getHash("*"), 3);
            prior.Add(Parsing.getHash("/"), 3);
            prior.Add(Parsing.getHash("div"), 3);
            prior.Add(Parsing.getHash("mod"), 3);
            prior.Add(Parsing.getHash("max"), 4);
            prior.Add(Parsing.getHash("min"), 4);

            for (int i = 0; i < c.Length; ++i)
                validSymbs.Add(c[i]);
            for (int i = '0'; i <= '9'; ++i)
                validSymbs.Add((char)(i));
            for (int i = 'a'; i <= 'z'; ++i)
                validSymbs.Add((char)(i));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(path);

            Grid.DataSource = ds;
            Grid.DataMember = "ROW";
            for (int i = 1; i <= Grid.RowCount; ++i)
                Grid.Rows[i - 1].HeaderCell.Value = i.ToString();
            Grid.AutoResizeRowHeadersWidth(0, DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            for (int i = 0; i < sz; ++i)
                for (int j = 0; j < sz; ++j)
                {
                    Table[i, j] = new string(Grid.Rows[i].Cells[j].Value.ToString().ToCharArray());
                    CalcItem(i, j);
                }

        }

        private string Calc(string expr, int idx)
        {
            List<Atom> infix = Parsing.getAtoms(expr);

            List<Atom> postfix = new List<Atom>();

            Stack<Atom> Symbs = new Stack<Atom>();

            for (int i = 0; i < infix.Count; ++i)
                if (infix[i].getType() == "OPER")
                {
                    if (Symbs.Count != 0)
                    {
                        if (infix[i].getValue() == "(")
                            Symbs.Push(infix[i]);
                        else
                        if (infix[i].getValue() == ")")
                        {
                            while (Symbs.Peek().getValue() != "(")
                            {
                                postfix.Add(Symbs.Peek());
                                Symbs.Pop();
                            }
                            Symbs.Pop();
                        }
                        else
                        {
                            while (Symbs.Count != 0 && prior[Parsing.getHash(infix[i].getValue())] <= prior[Parsing.getHash(Symbs.Peek().getValue())])
                            {
                                postfix.Add(Symbs.Peek());
                                Symbs.Pop();
                            }

                            Symbs.Push(infix[i]);
                        }
                    }
                    else
                        Symbs.Push(infix[i]);
                }
                else
                if (infix[i].getType() == "REF")
                {
                    refs.addEdge(idx, getItemNumber(infix[i].getValue()));
                    if (refs.isInCycle(idx))
                    {
                        var invalidCells = refs.availableFrom(idx);
                        for (int j = 0; j < invalidCells.Count; ++j)
                            Grid.Rows[invalidCells[j] / sz].Cells[invalidCells[j] % sz].Value = "ERROR";
                    }
                    postfix.Add(new NumAtom(getItemValue(infix[i].getValue())));
                }
                else
                    postfix.Add(infix[i]);

            while (Symbs.Count != 0)
            {
                postfix.Add(Symbs.Peek());
                Symbs.Pop();
            }

            Stack<Atom> Nums = new Stack<Atom>();
            for (int i = 0; i < postfix.Count; ++i)
                if (postfix[i].getType() == "OPER")
                {
                    Atom atom1 = Nums.Pop();
                    Atom atom2 = Nums.Pop();
                    Atom nAtom = new NumAtom(0);
                    if (postfix[i].getValue() == "+")
                    {
                        nAtom = new NumAtom(Parsing.StringToInt(atom1.getValue()) + Parsing.StringToInt(atom2.getValue()));
                    }
                    if (postfix[i].getValue() == "-")
                    {
                        nAtom = new NumAtom(Parsing.StringToInt(atom2.getValue()) - Parsing.StringToInt(atom1.getValue()));
                    }
                    if (postfix[i].getValue() == "*")
                    {
                        nAtom = new NumAtom(Parsing.StringToInt(atom1.getValue()) * Parsing.StringToInt(atom2.getValue()));
                    }
                    if (postfix[i].getValue() == "/")
                    {
                        nAtom = new NumAtom(Parsing.StringToInt(atom2.getValue()) / Parsing.StringToInt(atom1.getValue()));
                    }
                    if (postfix[i].getValue() == "div")
                    {
                        nAtom = new NumAtom(Parsing.StringToInt(atom2.getValue()) / Parsing.StringToInt(atom1.getValue()));
                    }
                    if (postfix[i].getValue() == "mod")
                    {
                        nAtom = new NumAtom(Parsing.StringToInt(atom2.getValue()) % Parsing.StringToInt(atom1.getValue()));
                    }
                    if (postfix[i].getValue() == "max")
                    {
                        nAtom = new NumAtom(Math.Max(Parsing.StringToInt(atom2.getValue()), Parsing.StringToInt(atom1.getValue())));
                    }
                    if (postfix[i].getValue() == "min")
                    {
                        nAtom = new NumAtom(Math.Min(Parsing.StringToInt(atom2.getValue()), Parsing.StringToInt(atom1.getValue())));
                    }
                    if (postfix[i].getValue() == "=")
                    {
                        if ((atom2.getValue() == atom1.getValue()))
                            nAtom = new NumAtom(1);
                        else
                            nAtom = new NumAtom(0);
                    }
                    if (postfix[i].getValue() == ">=")
                    {
                        if ((Parsing.StringToInt(atom2.getValue()) >= Parsing.StringToInt(atom1.getValue())))
                            nAtom = new NumAtom(1);
                        else
                            nAtom = new NumAtom(0);
                    }
                    if (postfix[i].getValue() == "<=")
                    {
                        if ((Parsing.StringToInt(atom2.getValue()) <= Parsing.StringToInt(atom1.getValue())))
                            nAtom = new NumAtom(1);
                        else
                            nAtom = new NumAtom(0);
                    }
                    if (postfix[i].getValue() == ">")
                    {
                        if ((Parsing.StringToInt(atom2.getValue()) > Parsing.StringToInt(atom1.getValue())))
                            nAtom = new NumAtom(1);
                        else
                            nAtom = new NumAtom(0);
                    }
                    if (postfix[i].getValue() == "<")
                    {
                        if ((Parsing.StringToInt(atom2.getValue()) < Parsing.StringToInt(atom1.getValue())))
                            nAtom = new NumAtom(1);
                        else
                            nAtom = new NumAtom(0);
                    }
                    if (postfix[i].getValue() == "<>")
                    {
                        if ((atom2.getValue() != atom1.getValue()))
                            nAtom = new NumAtom(1);
                        else
                            nAtom = new NumAtom(0);
                    }
                    Nums.Push(nAtom);
                }
                else
                    Nums.Push(postfix[i]);
            if (Nums.Count == 0)
                return "";
            else
                return Nums.Peek().getValue().ToString();
        }

        private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Table[e.RowIndex, e.ColumnIndex] = (Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            CalcItem(e.RowIndex, e.ColumnIndex);
        }

        private int getItemValue(string s)
        {
            string ans = Grid.Rows[s[1] - '0' - 1].Cells[s[0] - 'A'].Value.ToString();
            if (ans == "ERROR") throw new Exception();
            return Parsing.StringToInt(ans);
        }

        private int getItemNumber(string s)
        {
            return (s[1] - '0' - 1) * sz + (s[0] - 'A');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Table[e.RowIndex, e.ColumnIndex];
        }

        private void CalcItem(int i, int j, bool re = true)
        {
            if (Grid.Rows[i].Cells[j].Value == null)
                Grid.Rows[i].Cells[j].Value = "";
            try
            {
                refs.deleteEdgesFrom(i * sz + j);
                Grid.Rows[i].Cells[j].Value = Calc(Table[i, j], i * sz + j).ToString();
                //Calc(Grid.Rows[i].Cells[j].Value.ToString(), i * sz + j).ToString();
            }
            catch
            {
                Grid.Rows[i].Cells[j].Value = "ERROR";
            }
            if (re)
            {
                var recalc = refs.getInversed().availableFrom(i * sz + j);
                for (int k = 1; k < recalc.Count; ++k)
                    CalcItem(recalc[k] / sz, recalc[k] % sz, false);
            }
        }

        public void Save()
        {
            for (int i = 0; i < sz; ++i)
                for (int j = 0; j < sz; ++j)
                    Grid.Rows[i].Cells[j].Value = Table[i, j];

            ds.WriteXml(path);

            for (int i = 0; i < sz; ++i)
                for (int j = 0; j < sz; ++j)
                    CalcItem(i, j);
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Операції, що підтримуються:\n+, -, *, /, div, mod, max, min, =, <, >, <=, >=, <>");
        }

        private void eTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseReq req = new CloseReq("eTable");
            //req.Close();
            req.Owner = this;
            req.ShowDialog();
        }
    }
}
