using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels.Interfaces
{
    interface IBlobUrl
    {
        /// <summary>
        /// Internal Blob storage URL to locate a resource.
        /// </summary>
        string BlobUrl { get; set; }
    }
}
