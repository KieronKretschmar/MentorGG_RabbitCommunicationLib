using RabbitCommunicationLib.Enumerals;
using RabbitCommunicationLib.Enums;
using System;

namespace RabbitCommunicationLib.TransferModels
{

    public class DemoAnalyzerInstructions : TransferModel
    {
        public Source Source { get; set; }
        public double FramesPerSecond { get; set; }
        public DateTime MatchDate { get; set; }
        public string ZippedFilePath { get; set; }
        public AnalyzerQuality Quality { get; set; }
    }
}
