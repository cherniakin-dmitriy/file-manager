using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Manager
{
    class defFileInfo:uFileInfo
    {
        public defFileInfo(FileInfo f):base(f)
        {

        }
        public override void Open()
        {
            System.Diagnostics.Process.Start(file.FullName);
        }
    }
}
