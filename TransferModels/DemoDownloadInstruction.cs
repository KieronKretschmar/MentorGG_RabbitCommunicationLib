using RabbitCommunicationLib.TransferModels.Interfaces;

namespace RabbitCommunicationLib.TransferModels
{
    public class DemoDownloadInstruction : TransferModel, IDownloadUrl
    {
        public string DownloadUrl { get; set; }
    }
}
