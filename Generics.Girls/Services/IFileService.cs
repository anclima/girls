using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Generics.Girls.Services
{
    public interface IFileService
    {
        public Task<string> ProcessFileAsync(IFormFile file);
    }
}
