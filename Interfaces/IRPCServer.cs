
using RabbitMQ.Client;
using RabbitTransfer.TransferModels;

namespace RabbitTransfer.Interfaces
{
    public interface IRPCServer<TConsumeModel ,TProduceModel>:
    IProducer<TProduceModel>,
    IConsumer<TConsumeModel>

        where TConsumeModel : ITransferModel
        where TProduceModel : ITransferModel
    {
        /// <summary>
        /// Abstract method to handle a Transfer Model and reply.
        /// </summary>
        /// <param name="properties">AMQP Properties</param>
        /// <param name="model">Received message</param>
        TProduceModel HandleMessageAndReply(IBasicProperties properties, TConsumeModel model);
    }
}