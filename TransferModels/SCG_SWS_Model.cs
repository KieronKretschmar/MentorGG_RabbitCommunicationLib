using RabbitCommunicationLib.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{    public class SCG_SWS_Model : TransferModel
    {
        public long UploaderId { get; set; }
        public string SharingCode { get; set; }
        public UploadType UploadType { get; set; }
    }
}

