using Microsoft.AspNetCore.Mvc;

namespace RadiSoftwareTeste.Application.Wallet.Controllers
{

    [Route("status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Wallet Online...");
        }
    }
}
