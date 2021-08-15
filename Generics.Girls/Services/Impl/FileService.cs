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
        private readonly ILogger<IFileReaderService> logger;
        private Func<FileType, IFileReaderService> fileReaderServiceDelegate;

        public FileService(ILogger<IFileReaderService> logger, Func<FileType, IFileReaderService> fileReaderServiceDelegate)
        {
            this.logger = logger;
            this.fileReaderServiceDelegate = fileReaderServiceDelegate;
            
        }

        public async Task<string> ProcessFileAsync(IFormFile file)
        {
            IFileReaderService fileReaderService = fileReaderServiceDelegate(FileType.CSV);

            try
            {
                return await fileReaderService.ReadFileAsync(file);
            }
            catch(Exception error)
            {
                logger.LogError($"Erro ao ler o arquivo!\n Erro: {error}");
                return null;
            }

        }
    }
}
