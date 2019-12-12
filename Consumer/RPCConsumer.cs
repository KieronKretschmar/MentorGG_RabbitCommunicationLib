using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitTransfer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static TransferModel;

namespace RabbitTransfer.Consumer
{
    public abstract class RPCConsumer<TConsumeModel, TProduceModel> : Consumer<TConsumeModel>
        where TConsumeModel: ITransferModel
        where TProduceModel: ITransferModel
    {
        public RPCConsumer(IQueueConnection queueConnection) : base(queueConnection) { }

        protected override void OnConsumerReceived(IModel channel, BasicDeliverEventArgs ea)
        {
            // Let the overidden method handle the message and return a response.

            TProduceModel replyModel = HandleMessageAndReply(
                ea.BasicProperties,
                TransferModelFactory<TConsumeModel>.FromBytes(ea.Body));

            channel.BasicAck(
                deliveryTag: ea.DeliveryTag,
                multiple: false);

            // Publish reply message

            byte[] responseBytes = replyModel.ToBytes();
            var replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = ea.BasicProperties.CorrelationId;

            channel.BasicPublish(
                exchange: "",
                routingKey: ea.BasicProperties.ReplyTo,
                basicProperties: replyProps,
                body: responseBytes);
        }

        protected abstract TProduceModel HandleMessageAndReply(IBasicProperties properties, TConsumeModel model);

        protected override void HandleMessage(IBasicProperties properties, TConsumeModel model)
        {
            throw new InvalidOperationException("RPC Consumer expects a replyMessage, use HandleMessageAndReply!");
        }
    }
}
