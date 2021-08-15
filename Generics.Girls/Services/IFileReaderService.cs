using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace Generics.Girls.Services
{
    public interface IFileReaderService
    {
        Task<string> ReadFileAsync(IFormFile file);
    }
}
