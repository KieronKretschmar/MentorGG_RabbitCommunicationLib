using RabbitCommunicationLib.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.Queues
{
    public class ExchangeQueueConnection : IExchangeQueueConnection
    {
        public IConnection Connection { get; set; }
        public string Exchange { get; set; }
        public string Queue { get; set; }


        /// <summary>
        /// Create a QueueConnection.
        /// </summary>
        /// <param name="rabbitUri">Rabbit URI</param>
        /// <param name="exchangeName">Queue Name</param>
        public ExchangeQueueConnection(string rabbitUri, string exchangeName, string queueName)
        {
            AssertValidValue("rabbitUrl", rabbitUri);
            AssertValidValue("exchangeName", exchangeName);
            AssertValidValue("exchangeName", queueName);

            Connection = ConnectionFactoryHelper.FromUriString(rabbitUri);
            Exchange = exchangeName;
            Queue = queueName;
        }

        /// <summary>
        /// Assert a value is not Null or Empty.
        /// </summary>
        /// <param name="key">Key to attach to Exception</param>
        /// <param name="value">Value to assert</param>
        internal static void AssertValidValue(string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(key);
            }
        }
    }
}
