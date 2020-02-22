﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.TransferModels;
using RabbitMQ.Client;

namespace RabbitCommunicationLib.Producer
{
    /// <summary>
    /// This is a producer, which publishes to an exchange instead of directly to a queue
    /// </summary>
    /// <remarks>Useful for fanout exchanges or other non-direct exchanges</remarks>
    public class FanoutProducer<TProduceModel> : IProducer<TProduceModel> where TProduceModel : ITransferModel
    {
        /// <summary>
        /// Bool, whether messages should be saved to disk
        /// </summary>
        private readonly bool _persistentMessageSending;

        /// <summary>
        /// Connection channel.
        /// </summary>
        private IModel channel;

        private IExchangeConnection _exchangeConnection;


        /// <summary>
        /// Set the AMQP Connection.
        /// </summary>
        /// <param name="connection"></param>
        public FanoutProducer(IExchangeConnection exchangeConnection, bool persistentMessageSending = true)
        {
            _exchangeConnection = exchangeConnection;
            _persistentMessageSending = persistentMessageSending;
        }

        /// <summary>
        /// Publish a message to the Queue Channel.
        /// </summary>
        /// <param name="correlationId">Correlation ID for the sent message</param>
        /// <param name="produceModel">Model to produce (Message)</param>
        public void PublishMessage(string correlationId, TProduceModel produceModel)
        {
            IBasicProperties props = channel.CreateBasicProperties();
            props.CorrelationId = correlationId;

            byte[] messageBody = produceModel.ToBytes();

            props.Persistent = _persistentMessageSending;

            channel.BasicPublish(
                exchange: _exchangeConnection.ExchangeName,
                routingKey: "",
                basicProperties: props,
                body: messageBody);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            channel = _exchangeConnection.Connection.CreateModel();

            channel.ExchangeDeclare(
                exchange: _exchangeConnection.ExchangeName,
                ExchangeType.Fanout,
                durable: true,
                autoDelete: false);

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Dispose();
            _exchangeConnection.Connection.Dispose();
            await Task.CompletedTask;
        }
    }
}
