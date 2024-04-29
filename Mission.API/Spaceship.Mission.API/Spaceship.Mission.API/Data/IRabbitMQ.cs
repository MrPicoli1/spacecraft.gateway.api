namespace Spaceship.Mission.API.Data
{
    public interface IRabbitMQ
    {
        public void Publish<T>(T message) where T : class;
        public string Consume();
    }
}
