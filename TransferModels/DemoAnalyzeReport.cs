namespace RabbitCommunicationLib.TransferModels
{

    public class DemoAnalyzeReport : TaskCompletedReport
    {
        public bool BlobDownloadFailed { get; set; } = false;
        public bool Unzipped { get; set; } = false;
        public bool DuplicateChecked { get; set; } = false;
        public bool IsDuplicate { get; set; } = false;
        public bool UploadedToRedis { get; set; } = false;

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
