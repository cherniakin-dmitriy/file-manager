using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETable
{
    class NumAtom: Atom
    {
        int value;
        public NumAtom(int v)
        {
            value = v;
        }
        public override string getValue()
        {
            return value.ToString();
        }
        public override string getType()
        {
            return "NUM";
        }
    }
}
