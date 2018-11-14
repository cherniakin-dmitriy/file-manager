using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ETable
{
    class OperAtom : Atom
    {
        string value;
        public OperAtom(string v)
        {
            value = v;
        }
        public override string getValue()
        {
            return value;
        }
        public override string getType()
        {
            return "OPER";
        }
    }
}
