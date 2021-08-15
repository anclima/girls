using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Xml;

namespace Generics.Girls.Services.Impl
{
    public class XmlReaderService : IFileReaderService
    {
        public async Task<string> ReadFileAsync(IFormFile file)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            using var fileStream = file.OpenReadStream();
            using XmlReader reader = XmlReader.Create(fileStream, settings);

            while (await reader.ReadAsync())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.WriteLine($"Start Element: {reader.Name}. Has Attributes? : {reader.HasAttributes}");
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine($"Inner Text: {reader.Value}");
                        break;
                    case XmlNodeType.EndElement:
                        Console.WriteLine($"End Element: {reader.Name}");
                        break;
                    default:
                        Console.WriteLine($"Unknown: {reader.NodeType}");
                        break;
                }
            }

            return null;
        }
    }
}
