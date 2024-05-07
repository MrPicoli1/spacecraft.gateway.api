using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Spaceship.Mission.API.Data
{
    public class MessageQueue : IRabbitMQ
    {
        public string Consume()
        {
            var factory = new ConnectionFactory() { HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            var consumer = new EventingBasicConsumer(channel);
            string mensagem = string.Empty;
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                mensagem = message;
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: "missions",
                                 autoAck: true,
                                 consumer: consumer);
            channel.Close();
            connection.Close();

            return mensagem;
        }
        public void Publish<T>(T message) where T : class
        {
            var factory = new ConnectionFactory() { HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "missions",
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "",
                                    routingKey: "missions",
                                    basicProperties: null,
                                    body: body);
            channel.Close();
            connection.Close();
        }
    }
}
