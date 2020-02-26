﻿
namespace RabbitCommunicationLib.TransferModels
{
    public class TaskCompletedReport : TransferModel
    {
        /// <summary>
        /// Whether the task was completed successfully.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The version of the service that completed the task.
        /// </summary>
        public string Version { get; set; }
    }
}
