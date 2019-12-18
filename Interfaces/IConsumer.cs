
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace RabbitTransfer.Interfaces
{
    public interface IConsumer<TConsumeModel>: IHostedService

        where TConsumeModel: ITransferModel
    {
        /// <summary>
        /// Abstract method to handle a Transfer Model.
        /// </summary>
        /// <param name="properties">AMQP Properties</param>
        /// <param name="model">Received message</param>
        void HandleMessage(IBasicProperties properties, TConsumeModel model);
    }
}