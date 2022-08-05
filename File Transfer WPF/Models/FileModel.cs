using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Transfer_WPF.Models
{
    internal class FileModel
    {

        private string _extension;

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public bool IsSelected { get; set; } = true;
    }
}
