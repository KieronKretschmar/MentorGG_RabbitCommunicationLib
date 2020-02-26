using RabbitCommunicationLib.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    public class DemoEntryInstructions : TransferModel
    {
        public string DownloadUrl { get; set; }
        public DateTime MatchDate { get; set; }
        public long UploaderId { get; set; }
        public Source Source { get; set; }
        public UploadType UploadType { get; set; }
    }
}
