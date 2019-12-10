
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ.Abstract
{
    /// <summary>
    /// An Abstract IHostedService RPC Server with managed Start and Stop calls.
    /// </summary>
    public abstract class RPCServerService: IHostedService
    {
        /// <summary>
        /// Rabbit Queue to consume messages from.
        /// </summary>
        public abstract string QueueName { get; }

        /// <summary>
        /// Connection to the AMQP Rabbit Instance.
        /// </summary>
        private readonly IConnection _connection;


        /// <summary>
        /// Set the AMQP Connection.
        /// </summary>
        /// <param name="connection"></param>
        protected RPCServerService(IConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Handle the event if a message is received
        /// There is no guarantee on the model used in the message bytes
        /// You do not need to send out the response, just return its byte[] (JSON, utf8 encoded)
        /// </summary>
        /// <param name="matchId">id of the demo</param>
        /// <param name="response">byte [] of the received message</param>
        /// <returns>string to send back</returns>
        protected abstract string HandleMessageRecieved(long matchId, string response);

        /// <summary>
        /// Handle the event if a Rabbit consumer receives a message.
        /// </summary>
        /// <param name="channel">AMQP Connection channel</param>
        /// <param name="ea">Event Arguments</param>
        protected void OnConsumerReceived(IModel channel, BasicDeliverEventArgs ea)
        {
            long matchId = long.Parse(ea.BasicProperties.CorrelationId);
            var props = ea.BasicProperties;

            var replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;

            string decodedResponse = Encoding.UTF8.GetString(ea.Body);

            // Let the overidden method handle the message and return a response.
            string responseModel = HandleMessageRecieved(matchId, decodedResponse);
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseModel);


            channel.BasicPublish(
                exchange: "",
                routingKey: props.ReplyTo,
                basicProperties: replyProps,
                body: responseBytes);

            channel.BasicAck(
                deliveryTag: ea.DeliveryTag,
                multiple: false);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(
                queue: QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false);

            var consumer = new EventingBasicConsumer(channel);

            // Subscribe to the Consumer Received event.
            consumer.Received += (model, ea) => OnConsumerReceived(channel, ea);

            channel.BasicConsume(
                queue: QueueName,
                autoAck: false,
                consumer: consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _connection.Close();
            _connection.Dispose();

            return Task.CompletedTask;
        }
    }
}
