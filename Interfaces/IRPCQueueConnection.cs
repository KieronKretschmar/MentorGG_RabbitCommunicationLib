using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitTransfer.Interfaces
{
    public interface IRPCQueueConnection : IQueueConnection
    {
        /// <summary>
        /// Queue to listen for replies
        /// </summary>
        string ReplyQueue { get; set; }
    }
}
