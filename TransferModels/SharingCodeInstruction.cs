using RabbitCommunicationLib.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions for SteamworksService to extract data from a SharingCode and pass it on to DemoCentral.
    /// </summary>
    public class SharingCodeInstruction: TransferModel
    {
        /// <summary>
        /// SteamId of the person uploading the Demo.
        /// </summary>
        public long UploaderId { get; set; }

        /// <summary>
        /// SharingCode for the Demo.
        /// </summary>
        public string SharingCode { get; set; }

        /// <summary>
        /// The method used to obtain the SharingCode.
        /// </summary>
        public UploadType UploadType { get; set; }
    }
}

