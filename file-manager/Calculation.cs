using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETable
{
    public class Calculation
    {
        Dictionary<int, int> prior = new Dictionary<int, int>();
        public Calculation()
        {
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

        }

        public string Calc(string expr)
        {
            try
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
            catch
            {
                return "";
            }
        }


    }
}
