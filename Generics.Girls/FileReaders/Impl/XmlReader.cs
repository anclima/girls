using System;
using System.Xml;

using Microsoft.AspNetCore.Http;

namespace Generics.Girls.Services.Impl
{
    public class XmlReader : IFileReader
    {
        public string ReadFile(IFormFile file)
        {
            XmlReaderSettings settings = new()
            {
                IgnoreWhitespace = true
            };

            using var fileStream = file.OpenReadStream();
            using System.Xml.XmlReader reader = System.Xml.XmlReader.Create(fileStream, settings);

            while (reader.Read())
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
