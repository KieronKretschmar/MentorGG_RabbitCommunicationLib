using RabbitMQ.Client;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using RabbitCommunicationLib.Enums;

namespace RabbitCommunicationLib.Consumer
{
    /// <summary>
    /// Provide a concrete implementation of a consumer so the <see cref="Consumer{TConsumeModel}.HandleMessageAsync(BasicDeliverEventArgs, TConsumeModel)"/> function can be overwritten
    /// </summary>
    /// <typeparam name="TConsumeModel"></typeparam>
    public class ActionConsumer<TConsumeModel> :
    Consumer<TConsumeModel>

        where TConsumeModel : ITransferModel
    {
        /// <summary>
        /// Store the function which handles the received message
        /// </summary>
        private readonly Func<BasicDeliverEventArgs, TConsumeModel, Task<ConsumedMessageHandling>> _handleMessageAction;

        /// <summary>
        /// Create a Consumer, which <see cref="HandleMessageAsync(BasicDeliverEventArgs, TConsumeModel)"/> function can be overwritten via an action passed to the controller
        /// </summary>
        /// <param name="queueConnection"></param>
        /// <param name="handleReply">function, which is going to handle the received message</param>
        public ActionConsumer(IQueueConnection queueConnection, Func<BasicDeliverEventArgs, TConsumeModel, Task<ConsumedMessageHandling>> handleReply, ushort prefetchCount = 1) : base(queueConnection, prefetchCount)
        {
            _handleMessageAction = handleReply;
        }

        public override async Task<ConsumedMessageHandling> HandleMessageAsync(BasicDeliverEventArgs ea, TConsumeModel model)
        {
            return await _handleMessageAction(ea, model).ConfigureAwait(false);
        }
    }
}
