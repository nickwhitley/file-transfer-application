using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Transfer_WPF.Models
{
    internal class TransferModel : ITransferModel
    {

        public string SourceFolderPath { get; set; }
        public string DestinationFolderPath { get; set; }
        public string FileTypes { get; set; }

        public TransferModel()
        {

        }

        public void CommitFileTransfer(string sourceFolder, string destinationFolder)
        {

        }
    }
}
