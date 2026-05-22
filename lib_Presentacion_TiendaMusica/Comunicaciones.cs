using System.Text;
using System.Text.Json;

namespace lib_presentacion_TiendaMusica
{
    public class Comunicaciones
    {
        private readonly string _urlBase;

        public Comunicaciones(string urlBase)
        {
            _urlBase = urlBase;
        }

        public async Task<T?> Get<T>(string endpoint)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{_urlBase}/{endpoint}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<T?> Post<T>(string endpoint, object body)
        {
            using var client = new HttpClient();
            var content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_urlBase}/{endpoint}", content);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}