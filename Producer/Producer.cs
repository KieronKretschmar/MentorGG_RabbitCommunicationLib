using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitTransfer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitTransfer.Producer
{
    public abstract class Producer<TProduceModel> : IHostedService
        where TProduceModel: ITransferModel
    {
        /// <summary>
        /// Connection to the AMQP Rabbit Instance.
        /// </summary>
        private readonly IQueueConnection _queueConnection;

        /// <summary>
        /// Connection channel.
        /// </summary>
        private IModel channel;

        /// <summary>
        /// Set the AMQP Connection.
        /// </summary>
        /// <param name="connection"></param>
        protected Producer(IQueueConnection queueConnection)
        {
            _queueConnection = queueConnection;
        }

        public async Task PublishMessageAsync(string correlationId, TProduceModel produceModel)
        {
            IBasicProperties props = channel.CreateBasicProperties();
            props.CorrelationId = correlationId;

            byte[] messageBody = produceModel.ToBytes();

            channel.BasicPublish(
                exchange: "",
                routingKey: _queueConnection.QueueName,
                basicProperties: props,
                body: messageBody);

            await Task.CompletedTask;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            channel = _queueConnection.Connection.CreateModel();

            channel.QueueDeclare(
                queue: _queueConnection.QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false);

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
