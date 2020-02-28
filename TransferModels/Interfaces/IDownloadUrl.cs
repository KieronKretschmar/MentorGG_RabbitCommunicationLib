using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels.Interfaces
{
    interface IDownloadUrl
    {
        /// <summary>
        /// External URL to Download a resource
        /// </summary>
        string DownloadUrl { get; set; }
    }
}
