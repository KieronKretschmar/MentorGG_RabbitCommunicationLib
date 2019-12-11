using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitTransfer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitTransfer.Consumer
{
    public abstract class RPCConsumer : Consumer
    {
        public RPCConsumer(IQueueConnection queueConnection) : base(queueConnection) { }

        protected override void OnConsumerReceived(IModel channel, BasicDeliverEventArgs ea)
        {
            // Let the overidden method handle the message and return a response.

            var replyMessage = HandleMessageAndReply(
                ea.BasicProperties,
                Encoding.UTF8.GetString(ea.Body));

            channel.BasicAck(
                deliveryTag: ea.DeliveryTag,
                multiple: false);

            // Publish reply message

            byte[] responseBytes = Encoding.UTF8.GetBytes(replyMessage);
            var replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = ea.BasicProperties.CorrelationId;

            channel.BasicPublish(
                exchange: "",
                routingKey: ea.BasicProperties.ReplyTo,
                basicProperties: replyProps,
                body: responseBytes);
        }

        protected abstract string HandleMessageAndReply(IBasicProperties properties, string message);

        protected override void HandleMessage(IBasicProperties properties, string message)
        {
            throw new InvalidOperationException("RPC Consumer expects a replyMessage, use HandleMessageAndReply!");
        }
    }
}
