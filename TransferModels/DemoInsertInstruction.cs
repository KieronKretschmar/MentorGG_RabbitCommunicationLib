﻿using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions regarding the insertion of a new demo identified at external Demo provider, e.g. Valve's or Faceit's servers.
    /// </summary>
    public class DemoInsertInstruction : TransferModel, IDownloadUrl
    {
        public string DownloadUrl { get; set; }

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
        /// The method used to obtain the SharingCode.
        /// </summary>
        public UploadType UploadType { get; set; }
    }
}
