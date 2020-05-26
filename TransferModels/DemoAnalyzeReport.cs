using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels.Interfaces;
using System;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Report from DemoFileWorker regarding analysis of a demo file.
    /// </summary>
    public class DemoAnalyzeReport : TaskCompletedReport, IMatchId
    {
        /// <summary>
        /// The step during which the analysis failed, or null if it succeeded.
        /// </summary>
        public DemoAnalysisBlock? Block { get; set; }

        /// <summary>
        /// Redis key to locate the resource.
        /// </summary>
        public string RedisKey { get; set; }

        /// <summary>
        /// Date of expiry for this resource.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Unique identifier of the Demo.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="matchId"></param>
        public DemoAnalyzeReport(long matchId) : base(matchId)
        {
            Block = null;
        }
    }
}
