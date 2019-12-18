using System;
using System.Collections.Generic;
using System.Text;
namespace RabbitTransfer.TransferModels
{    public class SCG_SWS_Model : TransferModel
    {
        public long UploaderId { get; set; }
        public string SharingCode { get; set; }
        public byte UploadType { get; set; }
    }
}

