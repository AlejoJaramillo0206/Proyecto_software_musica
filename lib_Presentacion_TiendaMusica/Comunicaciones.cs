using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonException = Newtonsoft.Json.JsonException;

namespace lib_Presentacion_TiendaMusica
{
    public class Comunicaciones
    {

        public async Task<T> Ejecutar<T>(Dictionary<string, object> datos)
        {
            var url = datos["Url"].ToString();
            datos.Remove("Url");

            var stringData = datos.ContainsKey("Entidad") ?
                JsonConvert.SerializeObject(datos["Entidad"]) : "{}";
            var body = new StringContent(stringData, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 4, 0);

            HttpResponseMessage message;

            if (datos.ContainsKey("Entidad") && datos.ContainsKey("EsEditar"))
                message = await httpClient.PutAsync(url, body);
            else if (datos.ContainsKey("Entidad"))
                message = await httpClient.PostAsync(url, body);
            else if (datos.ContainsKey("EsEliminar"))
                message = await httpClient.DeleteAsync(url);
            else
                message = await httpClient.GetAsync(url);

            if (!message.IsSuccessStatusCode)
            {
                var errorBody = await message.Content.ReadAsStringAsync();
                try
                {
                    var errorObj = JsonConvert.DeserializeObject<dynamic>(errorBody);
                    string mensajeError = errorObj?.detail ?? errorObj?.message ?? errorObj?.title ?? errorBody;
                    throw new Exception(mensajeError);
                }
                catch (JsonException)
                {
                    throw new Exception(errorBody);
                }
            }

            var resp = await message.Content.ReadAsStringAsync();
            httpClient.Dispose();

            if (string.IsNullOrEmpty(resp))
                return default!;

            return JsonConvert.DeserializeObject<T>(resp)!;
        }
    }
}

