
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitCommunicationLib.TransferModels;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;

namespace RabbitCommunicationLib.Interfaces
{
    public interface IConsumer<TConsumeModel>: IHostedService

        where TConsumeModel: ITransferModel
    {
        /// <summary>
        /// Abstract method to handle a Transfer Model.
        /// </summary>
        /// <param name="properties">AMQP Properties</param>
        /// <param name="model">Received message</param>
        Task HandleMessageAsync(BasicDeliverEventArgs ea, TConsumeModel model);
    }
}