using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rnds.Girls.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalRecordController : ControllerBase
    {
        private readonly ILogger<MedicalRecordController> _logger;

        public MedicalRecordController(ILogger<MedicalRecordController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return null;
        }
    }
}
