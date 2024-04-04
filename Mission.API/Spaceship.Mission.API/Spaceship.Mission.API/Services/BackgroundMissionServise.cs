using Spaceship.Mission.API.Extensions;

namespace Spaceship.Mission.API.Services
{
    public class BackgroundMissionServise : IHostedService, IDisposable
    {
        private readonly HttpClientExtensions _httpClientExtensions;
        private Timer _timer;
        public BackgroundMissionServise(HttpClientExtensions httpClientExtensions, Timer timer)
        {
            _httpClientExtensions = httpClientExtensions;
            _timer = timer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
