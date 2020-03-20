using RabbitMQ.Client;

namespace RabbitCommunicationLib.Interfaces
{
    public interface IExchangeQueueConnection : IQueueConnection, IExchangeConnection
    {
         IConnection Connection { get; set; }
        string Queue { get; set; }
        string Exchange { get; set; }
    }
}