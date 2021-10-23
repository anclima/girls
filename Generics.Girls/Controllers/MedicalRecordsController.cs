using System;
using System.Threading.Tasks;
using Generics.Girls.Filters;
using Generics.Girls.HttpClients;
using Generics.Girls.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generics.Girls.Controllers
{
    [Route("api/v1/")]
    public class MedicalRecordsController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IGirlsBrokerHttpClient _girlsClient;

        public MedicalRecordsController(IFileService fileService, IGirlsBrokerHttpClient girlsClient)
        {
            _fileService = fileService;
            _girlsClient = girlsClient;
        }

        //[FileFilter]
        [HttpPost]
        [Route("rel")]
        public async Task<IActionResult> UploadFile()
        {
            var files = HttpContext.Request.Form.Files;

            if (HttpContext.Response.StatusCode == 415)
                return StatusCode(415);

            if (files.Count == 0)
                return BadRequest(new { Erro = "Arquivos nulos" });

            try
            {
                foreach (var file in files)
                {
                    var result = _fileService.ProcessFile(file);
                    await _girlsClient.PostAsync(result);

                    if (result != null)
                        return Ok(result);
                }

                return UnprocessableEntity(new { Erro = "Erro ao processar um ou mais arquivos." });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { Erro = $"Erro ao processar o arquivo. Erro: {error}" });
            }
        }
    }
}
