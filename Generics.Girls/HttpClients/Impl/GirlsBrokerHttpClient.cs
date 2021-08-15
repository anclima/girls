using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> PostMiddleModelAsync()
        {
            var uri = "";
            try
            {
                var response = await httpClient.PostAsync(uri, null);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
