namespace RabbitCommunicationLib.TransferModels
{

    public class DemoAnalyzeReport : TaskCompletedReport
    {
        public bool Unzipped { get; set; } = false;
        public bool DuplicateChecked { get; set; } = false;
        public bool IsDuplicate { get; set; } = false;
        public bool UploadedToRedis { get; set; } = false;
        public int FramesPerSecond { get; set; }
        public string zippedFilePath { get; set; }
        public string Hash { get; set; }
    }
}
