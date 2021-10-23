using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Generics.Girls.Utils;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Generics.Girls.Services.Impl
{
    public class FileService : IFileService
    {
        private readonly ILogger<IFileReader> logger;
        private readonly Func<FileType, IFileReader> fileReaderServiceDelegate;

        public FileService(ILogger<IFileReader> logger, Func<FileType, IFileReader> fileReaderServiceDelegate)
        {
            this.logger = logger;
            this.fileReaderServiceDelegate = fileReaderServiceDelegate;
            
        }

        public string ProcessFile(IFormFile file)
        {
            IFileReader fileReaderService = fileReaderServiceDelegate(FileType.CSV);

            try
            {
                return fileReaderService.ReadFile(file);
            }
            catch(Exception error)
            {
                logger.LogError($"Erro ao ler o arquivo!\n Erro: {error}");
                return null;
            }

        }
    }
}
