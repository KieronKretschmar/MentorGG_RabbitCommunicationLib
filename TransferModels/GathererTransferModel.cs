using System;

namespace RabbitTransfer.TransferModels
{
    public class GathererTransferModel : TransferModel
    {
        public string DownloadUrl { get; set; }
        public DateTime MatchDate { get; set; }
        public long UploaderId { get; set; }
        public byte Source { get; set; }
        public byte UploadType { get; set; }

    }
}
