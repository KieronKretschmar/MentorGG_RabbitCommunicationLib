using RabbitCommunicationLib.TransferModels.Interfaces;
using System;

namespace RabbitCommunicationLib.TransferModels
{

    public class DemoAnalyzeReport : TaskCompletedReport, IMatchId
    {
        /// <summary>
        /// If not null, state of which the analyzation failed.
        /// </summary>
        public DemoAnalyzeFailure Failure { get; set; }

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

    /// <summary>
    /// Possible failures when Analzing a Demo.
    /// </summary>
    public enum DemoAnalyzeFailure {

        /// <summary>
        /// Indicates the Blob Download failed.
        /// </summary>
        BlobDownload,

        /// <summary>
        /// Indicates Storage to Redis failed.
        /// </summary>
        RedisStorage,

        /// <summary>
        /// Indicates Unzipping Failed.
        /// </summary>
        Unzip,

        /// <summary>
        /// Indicates the Demo was a duplicate.
        /// </summary>
        Duplicate,

        /// <summary>
        /// Indicates the Analyze step failed.
        /// </summary>
        Analyze,

        /// <summary>
        /// Indicates the Enrich step failed.
        /// </summary>
        Enrich
    }
}
