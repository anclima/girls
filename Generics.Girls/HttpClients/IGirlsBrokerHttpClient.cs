using System.Threading.Tasks;

namespace Generics.Girls.HttpClients
{
    interface IGirlsBrokerHttpClient
    {
        public Task<bool> PostMiddleModelAsync();
    }
}
