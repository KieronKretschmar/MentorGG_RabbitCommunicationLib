using RabbitCommunicationLib.TransferModels.Interfaces;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions to download a demo.
    /// </summary>
    public class DemoDownloadInstruction : TransferModel, IDownloadUrl, IMatchId
    {
        public long MatchId { get; set ; }

        public string DownloadUrl { get; set; }
    }
}
