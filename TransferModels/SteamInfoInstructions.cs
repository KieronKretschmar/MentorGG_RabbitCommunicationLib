using RabbitCommunicationLib.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{    public class SteamInfoInstructions : TransferModel
    {
        public long UploaderId { get; set; }
        public string SharingCode { get; set; }
        public UploadType UploadType { get; set; }
    }
}

