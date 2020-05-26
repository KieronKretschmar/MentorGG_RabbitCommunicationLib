using RabbitCommunicationLib.TransferModels.Interfaces;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Report regarding the download of a demo file.
    /// </summary>
    public class DemoDownloadReport : TransferModel, IBlobUrl, IMatchId
    {
        public long MatchId { get; set; }

        public string BlobUrl { get; set; }

        /// <summary>
        /// Indicates if the download was succsesful
        /// </summary>
        public bool Success { get; set; }
    }
}

