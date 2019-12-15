using RabbitTransfer.Interfaces;

namespace RabbitTransfer.Helpers
{
    class RPCQueueConnection : QueueConnection, IRPCQueueConnection
    {
        /// <summary>
        /// Create a QueueConnection.
        /// </summary>
        /// <param name="rabbitUri">Rabbit URI</param>
        /// <param name="queueName">Queue Name</param>
        /// <param name="replyQueueName">Reply Queue Name</param>
        public RPCQueueConnection(string rabbitUri, string queueName, string replyQueueName) : base(rabbitUri, queueName)
        {
            AssertValidValue("replyQueueName", replyQueueName);
            ReplyQueue = replyQueueName;
        }

        public string ReplyQueue { get; set; }
    }
}
