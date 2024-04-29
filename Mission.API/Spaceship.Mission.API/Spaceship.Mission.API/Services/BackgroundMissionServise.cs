using Spaceship.Mission.API.Data;
using Spaceship.Mission.API.Domain.Entities;
using Spaceship.Mission.API.Extensions;
using System.Text.Json;

namespace Spaceship.Mission.API.Services
{
    public class BackgroundMissionServise : IHostedService, IDisposable
    {
        private readonly HttpClientExtensions _httpClientExtensions;
        private readonly IRabbitMQ _rabbitMQ;
        private Timer? _timer;
        public BackgroundMissionServise(HttpClientExtensions httpClientExtensions, IRabbitMQ rabbitMQ)
        {
            _httpClientExtensions = httpClientExtensions;
            _rabbitMQ = rabbitMQ;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(ProcessMisson, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private async void ProcessMisson(object? state)
        {
            var message = _rabbitMQ.Consume();
            if (message != null)
            {
                try {
                    var mission = JsonSerializer.Deserialize<MissionModel>(message);

                    if (mission.EndMission >= DateTime.Now)
                    {
                        _rabbitMQ.Publish(mission);
                        return;
                    }

                   await _httpClientExtensions.Post("http://localhost:5000/api/missions", mission);
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message+"\n"+e.StackTrace);
                }
                }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}
