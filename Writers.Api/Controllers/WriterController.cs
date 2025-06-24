using Microsoft.AspNetCore.Mvc;
using Writers.Api.Models;
using Writers.Api.Repository;

namespace Writers.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WriterController : ControllerBase
    {
  
        private readonly ILogger<WriterController> _logger;
        private readonly IWriterRep _writerRep;

        public WriterController(ILogger<WriterController> logger, IWriterRep writerRep)
        {
            _logger = logger;
            _writerRep = writerRep;
        }

        [HttpGet]
        public IActionResult GetWriters()
        {
            _logger.LogInformation("Fetching all writers.");
            return Ok(_writerRep.GetWriters());
        }
        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            _logger.LogInformation("Fetching all writers.");
            return Ok(_writerRep.AddWriter(writer));
        }
        [HttpPost]
        public IActionResult RemoveWriter(Writer writer)
        {
            _logger.LogInformation("Fetching all writers.");
            return Ok(_writerRep.AddWriter(writer));
        }


    }
}
