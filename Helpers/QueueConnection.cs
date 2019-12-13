using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitTransfer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitTransfer.Helpers
{
    internal static class ConnectionFactoryHelper
    {
        /// <summary>
        /// Create a connection from a URI
        /// </summary>
        /// <param name="uriString">Rabbit URI</param>
        /// <returns>AMQP Conneciton</returns>
        public static IConnection FromUriString(string uriString)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(uriString)
            };
            return factory.CreateConnection();
        }
    }

    public class QueueConnection : IQueueConnection
    {
        /// <summary>
        /// Create a QueueConnection from a Configuration
        /// Enviroment Variables Used: [ AMQP_URI, AMQP_QUEUE ]
        /// </summary>
        public QueueConnection(IConfiguration configuration)
        {
            try
            {
                Connection = ConnectionFactoryHelper.FromUriString(configuration.GetValue<string>("AMQP_URI"));
                Queue = configuration.GetValue<string>("AMQP_QUEUE");

            }
            catch (Exception e)
            {
                throw new Exception("Failed to create AMQP Connection, Please check " +
                    "the enviroment variables are set correctly", e);
            }
        }

        /// <summary>
        /// Create a QueueConnection.
        /// </summary>
        /// <param name="rabbitUri">Rabbit URI</param>
        /// <param name="queueName">Queue Name</param>
        public QueueConnection(string rabbitUri, string queueName)
        {
            Connection = ConnectionFactoryHelper.FromUriString(rabbitUri);
            Queue = queueName;
        }

        public IConnection Connection { get; set; }
        public string Queue { get; set; }
    }
}
