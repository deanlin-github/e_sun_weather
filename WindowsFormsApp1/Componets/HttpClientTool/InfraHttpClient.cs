using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Infra.Core.Componets.HttpClientTool
{
    public class InfraHttpClient
    {
        public async Task<TResponse> Get<TResponse>(string url = "")
        {
            HttpResponseMessage resp = null;
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(url),
                Timeout = TimeSpan.FromSeconds(20)
            };

            using (client)
            {
                resp = await client.GetAsync(string.Empty);
                var resString = await resp.Content.ReadAsStringAsync();

                if (resp.IsSuccessStatusCode || resp.StatusCode == HttpStatusCode.BadRequest)
                {
                    return JsonConvert.DeserializeObject<TResponse>(resString);
                }
                else
                {
                    throw new Exception($"GET remote host error => URL:{url}, Reponse:{resString}");
                }
            }
        }
    }
}
