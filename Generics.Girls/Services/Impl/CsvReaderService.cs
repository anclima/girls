using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

using Generics.Girls.Dtos;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Generics.Girls.Services.Impl
{
    public class CsvReaderService : IFileReaderService
    {
        public async Task<string> ReadFileAsync(IFormFile file)
        {
            try
            {
                var listObjResult = new List<Dictionary<string, string>>();
                
                var fileContentInListFormat = await ParseFileToList(file);

                var properties = fileContentInListFormat[0];

                for (int i = 1; i < fileContentInListFormat.Count; i++)
                {
                    var objResult = new Dictionary<string, string>();
                    for (int j = 0; j < properties.Length; j++)
                        objResult.Add(properties[j], fileContentInListFormat[i][j]);

                    listObjResult.Add(objResult);
                }

                var json = System.Text.Json.JsonSerializer.Serialize(listObjResult[0], new JsonSerializerOptions { WriteIndented = true });
                var result = JsonConvert.DeserializeObject<MedicalRecordDto>(json);

                return JsonConvert.SerializeObject(result);
            }
            catch (Exception e )
            {

                throw e;
            }
        }

        private static async Task<List<string[]>> ParseFileToList(IFormFile file)
        {
            using var fileStream = file.OpenReadStream();
            using var streamReader = new StreamReader(fileStream);
            var line = "";
            var csv = new List<string[]>();

            while (!streamReader.EndOfStream)
            {
                line = await streamReader.ReadLineAsync();
                csv.Add(line.Split(';'));
            }

            return csv;
        }
    }
}
