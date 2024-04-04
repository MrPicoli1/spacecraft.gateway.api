namespace Spaceship.Gateway.Data.RabbitMq
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(T message) where T : class;
    }
}
