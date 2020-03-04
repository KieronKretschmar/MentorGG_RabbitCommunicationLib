using RabbitCommunicationLib.TransferModels.Interfaces;
using System;

namespace RabbitCommunicationLib.TransferModels
{

    public class DemoAnalyzeReport : TaskCompletedReport, IMatchId
    {
        public long MatchId { get; set; }
        public bool BlobDownloadFailed { get; set; } = false;
        public bool Unzipped { get; set; } = false;
        public bool DuplicateChecked { get; set; } = false;
        public bool IsDuplicate { get; set; } = false;
        public bool UploadedToRedis { get; set; } = false;

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
