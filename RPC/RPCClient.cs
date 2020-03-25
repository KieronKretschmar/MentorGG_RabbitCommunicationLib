using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitCommunicationLib.Consumer;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.Producer;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitCommunicationLib.RPC
{

    /// <summary>
    /// An Abstract IHostedService AMQP RPC Consumer with managed Start and Stop calls.
    ///
    /// Use this Producer if you want to send a message and receive a reply.
    /// </summary>
    /// <typeparam name="TProduceModel">Transfer Model to produce</typeparam>
    /// <typeparam name="TConsumeModel">Transfer Model to consume</typeparam>
    public abstract class RPCClient<TProduceModel, TConsumeModel> : RPCBase<TProduceModel, TConsumeModel>
        where TProduceModel : ITransferModel
        where TConsumeModel : ITransferModel
    {

        /// <summary>
        /// Set the AMQP Connection.
        /// </summary>
        /// <param name="connection"></param>
        protected RPCClient(IRPCQueueConnections queueConnections, bool persistantMessageSending = true, ushort prefetchCount = 1) : base(queueConnections, persistantMessageSending, prefetchCount)
        {
        }


        /// <summary>
        /// Publish a message using the attached producer.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="produceModel"></param>
        public void PublishMessage(TProduceModel produceModel) 
            => producer.PublishMessage(produceModel);
    }
}
