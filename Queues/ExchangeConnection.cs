using System;
using System.Collections.Generic;
using System.Text;
using RabbitCommunicationLib.Interfaces;
using RabbitMQ.Client;

namespace RabbitCommunicationLib.Queues
{
    public class ExchangeConnection : IExchangeConnection
    {
        public IConnection Connection { get; set; }
        public string Exchange { get; set; }


        /// <summary>
        /// Create a QueueConnection.
        /// </summary>
        /// <param name="rabbitUri">Rabbit URI</param>
        /// <param name="exchangeName">Queue Name</param>
        public ExchangeConnection(string rabbitUri, string exchangeName)
        {
            AssertValidValue("rabbitUrl", rabbitUri);
            AssertValidValue("exchangeName", exchangeName);

            Connection = ConnectionFactoryHelper.FromUriString(rabbitUri);
            Exchange = exchangeName;
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
