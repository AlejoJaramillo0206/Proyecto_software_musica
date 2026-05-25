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
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync($"{_urlBase}/{endpoint}");
                var json = await response.Content.ReadAsStringAsync();

                // Si la respuesta está vacía o es null, retornar null sin explotar
                if (string.IsNullOrWhiteSpace(json) || json == "null")
                    return default;

                return JsonSerializer.Deserialize<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch
            {
                return default;
            }
        }


        public async Task<T?> Post<T>(string endpoint, object body)
        {
            try
            {
                using var client = new HttpClient();
                var content = new StringContent(
                    JsonSerializer.Serialize(body),
                    Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{_urlBase}/{endpoint}", content);
                var json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(json) || json == "null")
                    return default;

                return JsonSerializer.Deserialize<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch
            {
                return default;
            }


        }
        public async Task<bool> Delete(string endpoint)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.DeleteAsync($"{_urlBase}/{endpoint}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<T?> Put<T>(string endpoint, object body)
        {
            try
            {
                using var client = new HttpClient();
                var content = new StringContent(
                    JsonSerializer.Serialize(body),
                    Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{_urlBase}/{endpoint}", content);
                var json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(json) || json == "null")
                    return default;

                return JsonSerializer.Deserialize<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch
            {
                return default;
            }
        }
    }
}