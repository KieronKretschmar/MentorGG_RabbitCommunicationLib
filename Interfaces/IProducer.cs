
using Microsoft.Extensions.Hosting;
using RabbitCommunicationLib.TransferModels;
using System;

namespace RabbitCommunicationLib.Interfaces
{
    public interface IProducer<TProduceModel> : IDisposable

        where TProduceModel: ITransferModel
    {
        /// <summary>
        /// Publish a message.
        /// </summary>
        /// <param name="correlationId">Correlation ID for the sent message</param>
        /// <param name="produceModel">Model to produce (Message)</param>
        void PublishMessage(TProduceModel produceModel, string correlationId = null);
    }
}