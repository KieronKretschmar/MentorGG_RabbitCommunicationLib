using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.Producer;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitCommunicationLib.Consumer;

namespace RabbitCommunicationLib.RPC
{
    /// <summary>
    /// An Abstract IHostedService AMQP RPC Consumer with managed Start and Stop calls.
    ///
    /// Use this Consumer if you want to reply to a received message.
    /// </summary>
    /// <typeparam name="TConsumeModel">Transfer Model to consume.</typeparam>
    /// <typeparam name="TProduceModel">Transfer Model to produce.</typeparam>
    public abstract class RPCServer<TConsumeModel, TProduceModel> : RPCBase<TProduceModel,TConsumeModel>
        where TConsumeModel : ITransferModel
        where TProduceModel : ITransferModel
    {
        /// <summary>
        /// Set the AMQP Connection.
        /// </summary>
        /// <param name="connection"></param>
        protected RPCServer(IRPCQueueConnections queueConnections, bool persistantMessageSending = true) : base(queueConnections, persistantMessageSending)
        {
        }

        /// <summary>
        /// Handle a message and publish a reply.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="model"></param>
        public override async Task HandleMessageAsync(BasicDeliverEventArgs ea, TConsumeModel model)
        {
            // Call the abstract method
            TProduceModel replyModel = await HandleMessageAndReplyAsync(ea, model).ConfigureAwait(false);
            // Publish the reply.
            producer.PublishMessage(replyModel, ea.BasicProperties.CorrelationId);
        }

        /// <summary>
        /// Abstract method to handle a Transfer Model and reply.
        /// </summary>
        /// <param name="properties">AMQP Properties</param>
        /// <param name="model">Received message</param>
        public abstract Task<TProduceModel> HandleMessageAndReplyAsync(BasicDeliverEventArgs ea, TConsumeModel model);

    }
}
