using System.Text.Json;
using System.Text;

namespace Spaceship.Mission.API.Extensions
{
    public class HttpClientExtensions
    {
        public async Task<T> Post<T>(string url, T obj) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var json = JsonSerializer.Serialize(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(url, data);
            return await responseMessage.Content.ReadFromJsonAsync<T>();
        }
    }
}
