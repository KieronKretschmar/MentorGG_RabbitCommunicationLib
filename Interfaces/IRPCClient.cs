
using RabbitMQ.Client;

namespace RabbitTransfer.Interfaces
{
    public interface IRPCClient<TProduceModel, TConsumeModel>:
    IProducer<TProduceModel>,
    IConsumer<TConsumeModel>
    {
        
    }
}