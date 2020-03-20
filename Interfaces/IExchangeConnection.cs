using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace RabbitCommunicationLib.Interfaces
{
    public interface IExchangeConnection
    {
            /// <summary>
            /// AMQP Connection
            /// </summary>
            IConnection Connection { get; set; }

            /// <summary>
            /// AMQP Queue to consume.
            /// </summary>
            string Exchange { get; set; }
    }
}
