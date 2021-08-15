using System;
using System.Threading.Tasks;

using Generics.Girls.Dtos;
using Generics.Girls.Filters;
using Generics.Girls.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generics.Girls.Controllers
{
    [Route("api/prontuario")]
    public class MedicalRecordController : Controller
    {
        private readonly IFileService fileService;

        public MedicalRecordController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [FileFilter]
        [HttpPost]
        [Route("upload")]
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
                    var result = await fileService.ProcessFileAsync(file);

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
