using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Transfer_Console
{
    internal class Data
    {
        public string SourceFolderPath { get; set; }
        public int NumOfSourceFiles { get; set; }
        public string TargetFolderPath { get; set; }
        public int NumOfTargetFolderFiles { get; set; }

        public Data()
        {

        }

        public void TransferFiles()
        {
            foreach(var file in Directory.GetFiles(SourceFolderPath))
            {
                string fileName = Path.GetFileName(file);
                File.Move(file, TargetFolderPath + "\\" + fileName);
            }
        }
    }
}
