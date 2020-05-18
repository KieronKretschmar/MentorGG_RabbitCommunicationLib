using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels.Interfaces;
using System;

namespace RabbitCommunicationLib.TransferModels
{

    public class DemoAnalyzeReport : TaskCompletedReport, IMatchId
    {
        /// <summary>
        /// If not null, state of which the analyzation failed.
        /// </summary>
        public DemoAnalysisBlock Block { get; set; }

        /// <summary>
        /// Redis key to locate the resource
        /// </summary>
        public string RedisKey { get; set; }

        /// <summary>
        /// Date of expiry for this resource
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// FPS the Demo was analyze with.
        /// </summary>
        public int FramesPerSecond { get; set; }

        /// <summary>
        /// Unique identifier of the Demo.
        /// </summary>
        public string Hash { get; set; }
    }
}
