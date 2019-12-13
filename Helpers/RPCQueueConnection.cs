using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitTransfer.Interfaces;

namespace RabbitTransfer.Helpers
{
    class RPCQueueConnection : QueueConnection, IRPCQueueConnection
    {
        /// <summary>
        /// Create a QueueConnection from a Configuration
        /// Enviroment Variables Used: [ AMQP_URI, AMQP_QUEUE, AMQP_REPLY_QUEUE ]
        /// </summary>
        public RPCQueueConnection(IConfiguration configuration) : base(configuration)
        {
            ReplyQueue = configuration.GetValue<string>("AMQP_REPLY_QUEUE");
        }

        /// <summary>
        /// Create a QueueConnection.
        /// </summary>
        /// <param name="rabbitUri">Rabbit URI</param>
        /// <param name="queueName">Queue Name</param>
        /// <param name="replyQueueName">Reply Queue Name</param>
        public RPCQueueConnection(string rabbitUri, string queueName, string replyQueueName) : base(rabbitUri, queueName)
        {
            ReplyQueue = replyQueueName;
        }

        public string ReplyQueue { get; set; }
    }
}
