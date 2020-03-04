using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels.Interfaces;
using System;

namespace RabbitCommunicationLib.TransferModels
{

    public class DemoAnalyzeInstruction : TransferModel, IBlobUrl, IMatchId
    {
        /// <inheritdoc/>
        public long MatchId { get; set; }

        /// <summary>
        ///  Source of the Demo.
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// FPS to analyze the Demo in.
        /// </summary>
        public double FramesPerSecond { get; set; }

        /// <summary>
        /// When the match happened.
        /// </summary>
        public DateTime MatchDate { get; set; }

        /// <summary>
        /// Location to retreive the Demo internally.
        /// </summary>
        public string BlobUrl { get; set; }

        /// <summary>
        /// Quality to analyze the Demo in
        /// </summary>
        public AnalyzerQuality Quality { get; set; }
    }
}
