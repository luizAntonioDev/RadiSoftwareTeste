using Microsoft.AspNetCore.Mvc;

namespace RadiSoftwareTeste.Application.Customer.Controllers
{
    [Route("status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Online...");
        }
    }
}
