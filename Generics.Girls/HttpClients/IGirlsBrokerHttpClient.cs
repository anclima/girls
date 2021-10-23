using System.Threading.Tasks;

namespace Generics.Girls.HttpClients
{
    public interface IGirlsBrokerHttpClient
    {
        public Task<bool> PostAsync(string json);
    }
}
