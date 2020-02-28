﻿using RabbitCommunicationLib.TransferModels.Interfaces;

namespace RabbitCommunicationLib.TransferModels
{
    public class DemoObtainReport : TransferModel, IBlobUrl
    {
        public long MatchId { get; set; }

        public string BlobUrl { get; set; }

        /// <summary>
        /// Indicates if the download was succsesful
        /// </summary>
        public bool Success { get; set; }
    }
}

