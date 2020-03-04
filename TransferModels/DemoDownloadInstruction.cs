using RabbitCommunicationLib.TransferModels.Interfaces;

namespace RabbitCommunicationLib.TransferModels
{
    public class DemoDownloadInstruction : TransferModel, IDownloadUrl, IMatchId
    {
        public long MatchId { get; set ; }

        public string DownloadUrl { get; set; }
    }
}
