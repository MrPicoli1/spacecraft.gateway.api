using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Spaceship.Gateway.Extensions.Http
{
    public class HttpClientExtensions
    {
        public async Task<List<T>> GetList<T>(string url) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(url);
            return await responseMessage.Content.ReadFromJsonAsync<List<T>>();
        }

        public async Task<T> Get<T>(string url) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(url);
            return await responseMessage.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Post<T>(string url, T obj) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var json = JsonSerializer.Serialize(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(url,data);
            return await responseMessage.Content.ReadFromJsonAsync<T>();
        }

    }
}
