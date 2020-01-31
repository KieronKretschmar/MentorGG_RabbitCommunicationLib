﻿using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitTransfer.Interfaces;
using RabbitTransfer.Producer;
using RabbitTransfer.TransferModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitTransfer.RPC
{
    /// <summary>
    /// An Abstract IHostedService AMQP RPC Consumer with managed Start and Stop calls.
    ///
    /// Use this Consumer if you want to reply to a received message.
    /// </summary>
    /// <typeparam name="TConsumeModel">Transfer Model to consume.</typeparam>
    /// <typeparam name="TProduceModel">Transfer Model to produce.</typeparam>
    public abstract class RPCServer<TConsumeModel, TProduceModel> :
    RPCClient<TProduceModel, TConsumeModel>,
    IRPCServer<TConsumeModel, TProduceModel>

        where TConsumeModel: ITransferModel
        where TProduceModel: ITransferModel
    {

        /// <summary>
        /// Set the AMQP Connections.
        /// </summary>
        public RPCServer(
            IRPCQueueConnections queueConnections,
            bool persistentMessageSending = true) : base(queueConnections, persistentMessageSending) { }

        /// <summary>
        /// Handle a message and publish a reply.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="model"></param>
        public override async Task HandleMessageAsync(IBasicProperties properties, TConsumeModel model)
        {
            // Call the abstract method
            TProduceModel replyModel = await HandleMessageAndReplyAsync(properties, model).ConfigureAwait(false);
            // Publish the reply.
            PublishMessage(properties.CorrelationId, replyModel);
        }

        /// <summary>
        /// Abstract method to handle a Transfer Model and reply.
        /// </summary>
        /// <param name="properties">AMQP Properties</param>
        /// <param name="model">Received message</param>
        public abstract Task<TProduceModel> HandleMessageAndReplyAsync(IBasicProperties properties, TConsumeModel model);

    }
}
