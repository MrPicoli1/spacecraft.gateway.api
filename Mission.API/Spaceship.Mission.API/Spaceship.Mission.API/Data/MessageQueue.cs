using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Spaceship.Mission.API.Data
{
    public class MessageQueue : IRabbitMQ
    {
        public string Consume<T>() where T : class
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };


            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "orders",
                      durable: false,
                      exclusive: false,
                      autoDelete: false,
                      arguments: null);
            string message = "";
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
            };
            channel.BasicConsume(queue: "orders",
                                 autoAck: true,
                                 consumer: consumer);

            return message;
        }
        public void Publish<T>(T message) where T : class
        {
            var factory = new ConnectionFactory() { HostName = "rabbit-server", Port = 5672, UserName = "guest", Password = "guest" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "missions",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "",
                                    routingKey: "missions",
                                    basicProperties: null,
                                    body: body);
        }
    }
}
