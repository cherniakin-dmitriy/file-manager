using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETable
{
    class Parsing
    {
        public static int getHash(string s)
        {
            const int p = 31;
            int d = p;
            const int mod = 12345;
            int res = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                res = (res + d * s[i]) % mod;
                d = (d * p) % mod;
            }
            return res;
        }

        public static int StringToInt(string s)
        {
            int ans = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '-') continue;
                ans *= 10;
                ans += s[i] - '0';
            }
            if (s[0] == '-')
                return -ans;
            else
                return ans;
        }

        public static List<Atom> getAtoms(string expr)
        {
            List<Atom> atoms = new List<Atom>();
            if (expr == "") return atoms;
            string oldexpr = expr;
            expr = "";
            for (int i = 0; i < oldexpr.Length; ++i)
            {
                if (oldexpr[i] == '-' && (i == 0 || oldexpr[i - 1] > '9' || oldexpr[i - 1] < '0'))
                    expr += '0';
                expr += oldexpr[i];
            }
            
            expr = expr.Replace(" ", "");
            Stack<string> oper = new Stack<string>();

            for (int i = 0; i < expr.Length - 2; ++i)
            {
                if (expr.Substring(i, 3) == "min" || expr.Substring(i, 3) == "max")
                {
                    oper.Push(expr.Substring(i, 3));
                    expr = expr.Remove(i, 3);
                }

                if (expr[i] == ',')
                    expr = expr.Remove(i, 1).Insert(i, oper.Pop());
            }

            int st = 0;
            string cur = expr[0].ToString();
            // 0 - shortoper, 1 - longoper, 2 - num, 3 - ref
            if (expr[0] >= '0' && expr[0] <= '9')
                st = 2;
            if (expr[0] >= 'a' && expr[0] <= 'z' || expr[0] == '<' || expr[0] == '>' || expr[0] == '=')
                st = 1;
            if (expr[0] >= 'A' && expr[0] <= 'Z')
                st = 3;

            for (int i = 1; i < expr.Length; ++i)
            {
                if (expr[i] >= '0' && expr[i] <= '9')
                {
                    if (st == 0 || st == 1)
                    {
                        Atom nAtom = new OperAtom(cur);
                        atoms.Add(nAtom);
                        cur = "";
                        st = 2;
                    }
                    if (st == 3)
                        st = 3;
                }
                else
                if (expr[i] >= 'A' && expr[i] <= 'Z')
                {
                    if (st == 0 || st == 1)
                    {
                        Atom nAtom = new OperAtom(cur);
                        atoms.Add(nAtom);
                        cur = "";
                    }
                    if (st == 2)
                    {
                        Atom nAtom = new NumAtom(StringToInt(cur));
                        atoms.Add(nAtom);
                        cur = "";
                    }
                    st = 3;
                }
                else
                if (expr[i] >= 'a' && expr[i] <= 'z' || expr[i] == '<' || expr[i] == '>' || expr[i] == '=')
                {
                    if (st == 0)
                    {
                        Atom nAtom = new OperAtom(cur);
                        atoms.Add(nAtom);
                        cur = "";
                    }
                    if (st == 2)
                    {
                        Atom nAtom = new NumAtom(StringToInt(cur));
                        atoms.Add(nAtom);
                        cur = "";
                    }
                    if (st == 3)
                    {
                        Atom nAtom = new RefAtom(cur);
                        atoms.Add(nAtom);
                        cur = "";
                    }
                    st = 1;
                }
                else
                {
                    if (st == 0 || st == 1)
                    {
                        Atom nAtom = new OperAtom(cur);
                        atoms.Add(nAtom);
                    }
                    if (st == 2)
                    {
                        Atom nAtom = new NumAtom(StringToInt(cur));
                        atoms.Add(nAtom);
                    }
                    if (st == 3)
                    {
                        Atom nAtom = new RefAtom(cur);
                        atoms.Add(nAtom);
                    }
                    st = 0;
                    cur = "";
                }
                cur += expr[i];
            }

            if (st == 0 || st == 1)
            {
                Atom nAtom = new OperAtom(cur);
                atoms.Add(nAtom);
            }
            if (st == 2)
            {
                Atom nAtom = new NumAtom(StringToInt(cur));
                atoms.Add(nAtom);
            }
            if (st == 3)
            {
                Atom nAtom = new RefAtom(cur);
                atoms.Add(nAtom);
            }

            /*string operParse = "";
            int numParse = 0;

            for (int i = 0; i < expr.Length; ++i)
            {
                if (expr[i] >= '0' && expr[i] <= '9')
                {
                    if (i != 0 && !(expr[i - 1] >= '0' && expr[i - 1] <= '9'))
                    {
                        Atom nAtom = new OperAtom(operParse);
                        atoms.Add(nAtom);
                        operParse = "";
                    }
                    numParse = numParse * 10 + expr[i] - '0';
                }
                else
                {
                    if (i != 0 && expr[i - 1] >= '0' && expr[i - 1] <= '9')
                    {
                        Atom nAtom = new NumAtom(numParse);
                        atoms.Add(nAtom);
                        numParse = 0;
                    }
                    else
                    if (i != 0 && !(expr[i - 1] >= 'a' && expr[i - 1] <= 'z'))
                    {
                        Atom nAtom = new OperAtom(operParse);
                        atoms.Add(nAtom);
                        operParse = "";
                    }
                    operParse += expr[i];
                }
            }

            if (expr.Length != 0)
                if (expr[expr.Length - 1] >= '0' && expr[expr.Length - 1] <= '9')
                {
                    Atom nAtom = new NumAtom(numParse);
                    atoms.Add(nAtom);
                    numParse = 0;
                }
                else
                {
                    Atom nAtom = new OperAtom(operParse);
                    atoms.Add(nAtom);
                    operParse = "";
                }*/

            return atoms;
        }
    }
}
