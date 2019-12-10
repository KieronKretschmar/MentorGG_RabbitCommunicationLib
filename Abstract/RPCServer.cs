﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace RabbitTransfer.Abstract
{
    /// <summary>
    /// An abstract of a RPC server
    /// You only need to specify which Queue to listen to, and what to do once a message is received
    /// </summary>
    public abstract class RPCServer : IDisposable
    {
        /// <summary>
        /// Queue to listen to
        /// </summary>
        public abstract string QUEUE_NAME
        {
            get;
        }

        private readonly IConnection _connection;

        /// <summary>
        /// Set up the communication handling basics
        /// CorrelationId gets automatically parsed
        /// Messages get automatically acknowledged and the response published
        /// </summary>
        protected RPCServer()
        {
            _connection = RabbitInitializer.GetNewConnection();
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: QUEUE_NAME, durable: false, exclusive: false, autoDelete: false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var response = ea.Body;
                long matchId = long.Parse(ea.BasicProperties.CorrelationId);
                var props = ea.BasicProperties;
                var replyProps = channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                string utf8decodedResponse = System.Text.Encoding.UTF8.GetString(response);

                string responseModel= OnMessageReceived(matchId, utf8decodedResponse);

                byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(responseModel);


                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(queue: QUEUE_NAME,
            autoAck: false,
            consumer: consumer);

        }

        /// <summary>
        /// Handle the event if a message is received
        /// There is no guarantee on the model used in the message bytes
        /// You do not need to send out the response, just return its byte[] (JSON, utf8 encoded)
        /// </summary>
        /// <param name="matchId">id of the demo</param>
        /// <param name="response">byte [] of the received message</param>
        /// <returns>string to send back</returns>
        protected abstract string OnMessageReceived(long matchId, string response);


        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void Dispose()
        {
            _connection.Close();
        }
    }
}