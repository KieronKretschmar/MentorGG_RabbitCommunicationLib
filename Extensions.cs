using Microsoft.Extensions.DependencyInjection;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.Producer;
using RabbitCommunicationLib.Queues;
using RabbitCommunicationLib.TransferModels;

namespace RabbitCommunicationLib.Extensions
{
    /// <summary>
    /// Collection of Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Extension Method for adding regular rabbit Producers to IServiceCollection.
        /// </summary>
        /// <typeparam name="TTransferModel"></typeparam>
        /// <param name="services"></param>
        /// <param name="amqpConnectionString"></param>
        /// <param name="queueName"></param>
        public static void AddProducer<TTransferModel>(this IServiceCollection services, string amqpConnectionString, string queueName)
            where TTransferModel : ITransferModel
        {
            var connection = new QueueConnection(amqpConnectionString, queueName);
            services.AddTransient<IProducer<TTransferModel>>(sp => new Producer<TTransferModel>(connection));
        }

        /// <summary>
        /// Extension Method for adding fanout rabbit Producers to IServiceCollection.
        /// </summary>
        /// <typeparam name="TTransferModel"></typeparam>
        /// <param name="services"></param>
        /// <param name="amqpConnectionString"></param>
        /// <param name="exchangeName"></param>
        public static void AddFanoutProducer<TTransferModel>(this IServiceCollection services, string amqpConnectionString, string exchangeName)
            where TTransferModel : ITransferModel
        {
            var connection = new ExchangeConnection(amqpConnectionString, exchangeName);
            services.AddTransient<IProducer<TTransferModel>>(sp => new FanoutProducer<TTransferModel>(connection));
        }
    }
}
