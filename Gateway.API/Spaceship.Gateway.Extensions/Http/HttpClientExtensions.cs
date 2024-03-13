using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Spaceship.Gateway.Extensions.Http
{
    public class HttpClientExtensions<T> where T : class
    {
        public async Task<List<T>> GetList(string url)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(url);
            return await responseMessage.Content.ReadFromJsonAsync<List<T>>();
        }

        public async Task<T> Get(string url)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(url);
            return await responseMessage.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Post(string url, T obj)
        {
            HttpClient httpClient = new HttpClient();
            var json = JsonSerializer.Serialize(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(url,data);
            return await responseMessage.Content.ReadFromJsonAsync<T>();
        }

    }
}
