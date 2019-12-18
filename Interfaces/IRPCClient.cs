
using RabbitMQ.Client;
using RabbitTransfer.TransferModels;

namespace RabbitTransfer.Interfaces
{
    public interface IRPCClient<TProduceModel, TConsumeModel> :
    IProducer<TProduceModel>,
    IConsumer<TConsumeModel>

        where TProduceModel : ITransferModel
        where TConsumeModel : ITransferModel
    {

    }
}