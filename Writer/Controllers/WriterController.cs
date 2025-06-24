using Microsoft.AspNetCore.Mvc;

namespace Writer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WriterController : ControllerBase
    {
        private readonly ILogger<WriterController> _logger;
        public WriterController(ILogger<WriterController> logger)
        {
            _logger = logger;
        }

    }
}
