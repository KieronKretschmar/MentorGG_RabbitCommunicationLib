
using Microsoft.Extensions.Hosting;
using RabbitTransfer.TransferModels;

namespace RabbitTransfer.Interfaces
{
    public interface IProducer<TProduceModel>: IHostedService

        where TProduceModel: ITransferModel
    {
        /// <summary>
        /// Publish a message.
        /// </summary>
        /// <param name="correlationId">Correlation ID for the sent message</param>
        /// <param name="produceModel">Model to produce (Message)</param>
        void PublishMessage(string correlationId, TProduceModel produceModel);
    }
}