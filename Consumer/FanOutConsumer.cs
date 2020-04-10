using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.TransferModels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitCommunicationLib.Consumer
{
    /// <summary>
    /// An Abstract IHostedService AMQP Consumer with managed Start and Stop calls.
    /// </summary>
    /// <typeparam name="TConsumeModel">Tranfer Model to consume.</typeparam>
    public abstract class FanOutConsumer<TConsumeModel> : IConsumer<TConsumeModel> where TConsumeModel : ITransferModel
    {

        /// <summary>
        /// Connection to the AMQP Rabbit Instance.
        /// </summary>
        private readonly IExchangeQueueConnection _queueConnection;

        /// <summary>
        /// PrefetchCount + 1 = Number of messages that are consumed simultaneously
        /// </summary>
        private readonly ushort _prefetchCount;

        /// <summary>
        /// Connection channel.
        /// </summary>
        private IModel channel;

        /// <summary>
        /// AMQP Rabbit Consumer.
        /// </summary>
        private EventingBasicConsumer consumer;


        /// <summary>
        /// Set the AMQP Connection.
        /// </summary>
        protected FanOutConsumer(IExchangeQueueConnection queueConnection, ushort prefetchCount = 1)
        {
            _queueConnection = queueConnection;
            _prefetchCount = prefetchCount;
        }

        /// <summary>
        /// Abstract method to handle a Transfer Model.
        /// 
        /// When overriding, you may or may not ack / nack the message. 
        /// Bear in mind, that if you do not do either of them, it will be done automatically 
        /// according to the logic in OnConsumerReceivedAsync.
        /// </summary>
        /// <param name="properties">AMQP Properties</param>
        /// <param name="model">Received message</param>
        public abstract Task<ConsumedMessageHandling> HandleMessageAsync(BasicDeliverEventArgs ea, TConsumeModel model);


        /// <summary>
        /// Basic Acknowledge a message
        /// </summary>
        /// <param name="ea">Event Arguments</param>
        private void BasicAcknowledge(BasicDeliverEventArgs ea)
        {
            channel.BasicAck(
                    deliveryTag: ea.DeliveryTag,
                    multiple: false);
        }

        /// <summary>
        /// BasicNacks a message, indicating failure to process it.
        /// </summary>
        /// <param name="ea"></param>
        /// <param name="requeue">Whether the message should be requeued.</param>
        private void BasicNack(BasicDeliverEventArgs ea, bool requeue)
        {
            channel.BasicNack(
                    deliveryTag: ea.DeliveryTag,
                    multiple: false,
                    requeue: requeue);
        }

        /// <summary>
        /// Handle the event if a Rabbit consumer receives a message.
        /// </summary>
        /// <param name="channel">AMQP Connection channel</param>
        /// <param name="ea">Event Arguments</param>
        protected virtual async Task OnConsumerReceivedAsync(IModel channel, BasicDeliverEventArgs ea)
        {
            // If a model cannot be obtained from the body,
            // throw away the message as no work can be done with an invalid model.
            TConsumeModel model;
            try
            {
                model = TransferModel.TransferModelFactory<TConsumeModel>.FromBytes(ea.Body);
            }
            catch
            {
                ThrowAwayMessage(ea);
                return;
            }

            try
            {
                var response = await HandleMessageAsync(ea, model).ConfigureAwait(false);

                switch (response)
                {
                    case ConsumedMessageHandling.Done:
                        AcknowledgeMessage(ea);
                        break;
                    case ConsumedMessageHandling.Resend:
                        ResendMessage(ea);
                        break;
                    case ConsumedMessageHandling.ThrowAway:
                        ThrowAwayMessage(ea);
                        break;
                }
            }
            catch (Exception e)
            {
                //This should never happen, all possible exceptions should be catched by the developer.
                Console.WriteLine($"Handling messaging failed due to unhandled exception {e}. This should never happen.");
                ThrowAwayMessage(ea);
            }
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Creating FanoutConsumer Channel [ {this._queueConnection.Exchange} ]");

            channel = _queueConnection.Connection.CreateModel();

            channel.ExchangeDeclare
                (
                _queueConnection.Exchange,
                ExchangeType.Fanout,
                durable:true,
                autoDelete:false
                );

            channel.QueueDeclare(
                queue: _queueConnection.Queue,
                durable: true,
                exclusive: false,
                autoDelete: false);

            channel.QueueBind
                (
                queue: _queueConnection.Queue,
                exchange:_queueConnection.Exchange,
                routingKey:"This gets ignored in a fanout exchange"
                );

            channel.BasicQos(0, _prefetchCount, false);

            consumer = new EventingBasicConsumer(channel);

            // Subscribe to the Consumer Received event.
            consumer.Received += async (model, ea) => await OnConsumerReceivedAsync(channel, ea).ConfigureAwait(false);

            channel.BasicConsume(
                queue: _queueConnection.Queue,
                autoAck: false,
                consumer: consumer);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            channel.ModelShutdown += (sender, ea) =>
            {
                consumer.HandleModelShutdown((IModel) sender, ea);
            };

            Console.WriteLine($"Disposing FanoutConsumer Channel [ {this._queueConnection.Exchange}  ]");
            channel.Dispose();
            _queueConnection.Connection.Dispose();
            await Task.CompletedTask.ConfigureAwait(false);
        }


        public void ResendMessage(BasicDeliverEventArgs ea) => BasicNack(ea, true);
        public void ThrowAwayMessage(BasicDeliverEventArgs ea) => BasicNack(ea, false);
        public void AcknowledgeMessage(BasicDeliverEventArgs ea) => BasicAcknowledge(ea);

    }
}
