
using RabbitMQ.Client;
using RabbitCommunicationLib.TransferModels;

namespace RabbitCommunicationLib.Interfaces
{
    public interface IRPCClient<TProduceModel, TConsumeModel> :
    IProducer<TProduceModel>,
    IConsumer<TConsumeModel>

        where TProduceModel : ITransferModel
        where TConsumeModel : ITransferModel
    {

    }
}