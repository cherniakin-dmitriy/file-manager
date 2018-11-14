using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ETable;

namespace Manager
{
    class xmlFileInfo: uFileInfo
    {
        public xmlFileInfo(FileInfo f):base(f)
        {

        }
        public override void Open()
        {
            eTable table = new eTable(file.FullName);
            table.Show();
        }
    }
}
