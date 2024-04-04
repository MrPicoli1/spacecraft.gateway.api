using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Spaceship.Gateway.Data.RabbitMq
{
    public class MQPRoducer : IMessageProducer
    {
        public void SendMessage<T>(T message)where T : class
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
