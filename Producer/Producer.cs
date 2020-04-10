using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitCommunicationLib.Producer
{
    public class Producer<TProduceModel> :
    IProducer<TProduceModel>

        where TProduceModel: ITransferModel
    {
        /// <summary>
        /// Connection to the AMQP Rabbit Instance.
        /// </summary>
        private readonly IQueueConnection _queueConnection;

        /// <summary>
        /// Bool, whether messages should be saved to disk
        /// </summary>
        private readonly bool _persistentMessageSending;

        /// <summary>
        /// Connection channel.
        /// </summary>
        private IModel channel;



        /// <summary>
        /// Set the AMQP Connection.
        /// </summary>
        /// <param name="connection"></param>
        public Producer(IQueueConnection queueConnection, bool persistentMessageSending = true)
        {
            _queueConnection = queueConnection;
            _persistentMessageSending = persistentMessageSending;


            Console.WriteLine($"Creating Producer Channel [ {this._queueConnection.Queue} ]");
            channel = _queueConnection.Connection.CreateModel();
            channel.QueueDeclare(
                queue: _queueConnection.Queue,
                durable: true,
                exclusive: false,
                autoDelete: false);
        }


        /// <summary>
        /// Publish a message to the Queue Channel.
        /// </summary>
        /// <param name="correlationId">Correlation ID for the sent message</param>
        /// <param name="produceModel">Model to produce (Message)</param>
        public void PublishMessage(TProduceModel produceModel, string correlationId = null)
        {
            correlationId = correlationId ?? Guid.NewGuid().ToString();

            IBasicProperties props = channel.CreateBasicProperties();
            props.CorrelationId = correlationId;

            byte[] messageBody = produceModel.ToBytes();

            props.Persistent = _persistentMessageSending;

            channel.BasicPublish(
                exchange: "",
                routingKey: _queueConnection.Queue,
                basicProperties: props,
                body: messageBody);
        }

        public void Dispose()
        {
            Console.WriteLine($"Disposing Producer Channel [ {this._queueConnection.Queue} ]");
            channel.Dispose();
        }
    }
}
