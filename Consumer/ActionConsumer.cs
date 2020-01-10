﻿using RabbitMQ.Client;
using RabbitTransfer.Interfaces;
using RabbitTransfer.TransferModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitTransfer.Consumer
{
    /// <summary>
    /// Provide a concrete implementation of a consumer so the <see cref="Consumer{TConsumeModel}.HandleMessageAsync(IBasicProperties, TConsumeModel)"/> function can be overwritten
    /// </summary>
    /// <typeparam name="TConsumeModel"></typeparam>
    public class ActionConsumer<TConsumeModel> :
    Consumer<TConsumeModel>

        where TConsumeModel : ITransferModel
    {
        /// <summary>
        /// Store the function which handles the received message
        /// </summary>
        private readonly Func<IBasicProperties, TConsumeModel, Task> _handleMessageAction;

        /// <summary>
        /// Create a Consumer, which <see cref="HandleMessageAsync(IBasicProperties, TConsumeModel)"/> function can be overwritten via an action passed to the controller
        /// </summary>
        /// <param name="queueConnection"></param>
        /// <param name="handleReply">function, which is going to handle the received message</param>
        public ActionConsumer(IQueueConnection queueConnection, Func<IBasicProperties, TConsumeModel, Task> handleReply) : base(queueConnection)
        {
            _handleMessageAction = handleReply;
        }

        public override async Task HandleMessageAsync(IBasicProperties properties, TConsumeModel model)
        {
            await _handleMessageAction(properties, model).ConfigureAwait(false);
        }
    }
}
