using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions regarding the insertion of a new demo that was downloaded through manual upload.
    /// </summary>
    public class ManualDownloadInsertInstructions : TransferModel
    {
        public string BlobUrl { get; set; }

        /// <summary>
        /// When the Match occured.
        /// </summary>
        public DateTime UploadDate { get; set; }

        /// <summary>
        /// When the Match occured.
        /// </summary>
        public DateTime MatchDate { get; set; }

        /// <summary>
        /// The SteamId of the Uploader.
        /// </summary>
        public long UploaderId { get; set; }

        /// <summary>
        /// Where the Demo came from.
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// The method used to Upload.
        /// </summary>
        public UploadType UploadType { get; set; }
    }
}
