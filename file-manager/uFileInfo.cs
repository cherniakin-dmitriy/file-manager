using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Manager
{
    abstract class uFileInfo
    {
        protected FileInfo file;
        public uFileInfo(FileInfo f)
        {
            file = f;
        }
        public abstract void Open();
    }
}
