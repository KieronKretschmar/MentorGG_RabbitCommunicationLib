
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitTransfer.TransferModels;
using System.Threading.Tasks;

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
        Task HandleMessageAsync(IBasicProperties properties, TConsumeModel model);
    }
}