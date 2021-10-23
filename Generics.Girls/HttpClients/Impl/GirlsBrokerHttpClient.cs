using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Generics.Girls.HttpClients.Impl
{
    public class GirlsBrokerHttpClient : IGirlsBrokerHttpClient
    {
        private readonly HttpClient httpClient;

        public GirlsBrokerHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> PostAsync(string json)
        {
            var uri = "";
            try
            {
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json"); ;
                var response = await httpClient.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
