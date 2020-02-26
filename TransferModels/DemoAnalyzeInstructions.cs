using RabbitCommunicationLib.Enums;
using System;

namespace RabbitCommunicationLib.TransferModels
{

    public class DemoAnalyzeInstructions : TransferModel
    {
        public Source Source { get; set; }
        public double FramesPerSecond { get; set; }
        public DateTime MatchDate { get; set; }
        public string BlobURI { get; set; }
        public AnalyzerQuality Quality { get; set; }
    }
}
