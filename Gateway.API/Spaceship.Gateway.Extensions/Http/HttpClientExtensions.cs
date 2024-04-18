using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Spaceship.Gateway.Extensions.Http
{
    public class HttpClientExtensions
    {
        public async Task<IEnumerable<T>> GetList<T>(string url) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(url);
            var response  = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<T>>();
            if (response != null)
            {
                return response;
            }
            throw new Exception("Could not get list from url");
        }

        public async Task<T> Get<T>(string url) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(url);

            var response = await responseMessage.Content.ReadFromJsonAsync<T>();
            if (response != null)
            {
                return response;
            }
            throw new Exception("Could not get list from url");
        }

        public async Task<T?> Post<T>(string url, T obj) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var json = JsonSerializer.Serialize(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(url,data);
            return await responseMessage.Content.ReadFromJsonAsync<T>();
        }

    }
}
