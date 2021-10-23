using System;
using System.IO;
using System.Globalization;

using CsvHelper.Configuration;

using Generics.Girls.Dtos;
using Generics.Girls.Utils;

using Microsoft.AspNetCore.Http;

namespace Generics.Girls.Services.Impl
{
    public class CsvReader : IFileReader
    {
        public string ReadFile(IFormFile file)
        {
            try
            {
                CsvConfiguration config = new(CultureInfo.InvariantCulture){ DetectDelimiter = true };
                using var reader = new StreamReader(file.OpenReadStream());
                using var csv = new CsvHelper.CsvReader(reader, config);

                csv.Context.RegisterClassMap<MedicalRecordCsvMap>();
                var records = csv.GetRecords<MedicalRecordDto>();

                return System.Text.Json.JsonSerializer.Serialize(records);
            }
            catch (Exception e)
            {
                var _ = e;
                return null;
            }
        }

    }
}
