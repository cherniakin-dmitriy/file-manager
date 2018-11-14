using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETable
{
    class RefAtom : Atom
    {
        string value;
        public RefAtom(string v)
        {
            value = v;
        }
        public override string getValue()
        {
            return value;
        }
        public override string getType()
        {
            return "REF";
        }
    }
}
