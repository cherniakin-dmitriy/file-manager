using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Manager
{
    class txtFileInfo: uFileInfo
    {
        public txtFileInfo(FileInfo f):base(f)
        {
            
        }
        public override void Open()
        {
            Editor editor = new Editor(file);
            editor.Show();
        }
    }
}
