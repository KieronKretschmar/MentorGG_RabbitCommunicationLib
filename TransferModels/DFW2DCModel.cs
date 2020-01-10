﻿namespace RabbitTransfer.TransferModels
{

    public class DFW2DCModel : TaskCompletedTransferModel
    {
        public bool Unzipped { get; set; } = false;
        public bool DuplicateChecked { get; set; } = false;
        public bool IsDuplicate { get; set; } = false;
        public bool UploadedToDb { get; set; } = false;
        public int FramesPerSecond { get; set; } = 1;
        public string zippedFilePath { get; set; }
        public string Hash { get; set; } = "";
    }
}
