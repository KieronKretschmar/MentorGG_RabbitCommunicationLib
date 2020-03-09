using RabbitCommunicationLib.Consumer;
using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.Producer;
using RabbitCommunicationLib.TransferModels;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitCommunicationLib.RPC
{
    /// <summary>
    /// Handles consumer, producer creation
    /// Start/Stop of hostedService
    /// Dispose of IDisposable
    /// </summary>
    /// <typeparam name="TProduceModel"></typeparam>
    /// <typeparam name="TConsumeModel"></typeparam>
    public abstract class RPCBase<TProduceModel, TConsumeModel>
        where TProduceModel : ITransferModel
        where TConsumeModel : ITransferModel
    {
        protected readonly Producer<TProduceModel> producer;
        protected readonly ActionConsumer<TConsumeModel> consumer;
        protected RPCBase(
            IRPCQueueConnections queueConnections,
            bool persistantMessageSending = true)
        {
            producer = new Producer<TProduceModel>(
                queueConnections.ProduceConnection,
                persistantMessageSending);

            consumer = new ActionConsumer<TConsumeModel>(
                queueConnections.ConsumeConnection,
                HandleMessageAsync);
        }

        public void ResendMessage(BasicDeliverEventArgs ea) => consumer.ResendMessage(ea);
        public void ThrowAwayMessage(BasicDeliverEventArgs ea) => consumer.ThrowAwayMessage(ea);

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await consumer.StartAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await consumer.StopAsync(cancellationToken).ConfigureAwait(false);
        }

        public void Dispose() => producer.Dispose();


        /// <summary>
        /// Abstract method to handle a Transfer Model. (A reply in this context)
        ///
        /// Overide this method to get the functionality.
        /// </summary>
        /// <param name="properties">headers of the message</param>
        /// <param name="consumeModel">Transfer Model of the message</param>
        public abstract Task<ConsumedMessageHandling> HandleMessageAsync(BasicDeliverEventArgs ea, TConsumeModel consumeModel);

    }
}
