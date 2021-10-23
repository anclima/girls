using Microsoft.AspNetCore.Http;

namespace Generics.Girls.Services
{
    public interface IFileReader
    {
        string ReadFile(IFormFile file);
    }
}
