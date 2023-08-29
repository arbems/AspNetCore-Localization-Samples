using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public HomeController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sharedLocalizer["Your application shared resources."].Value);
        }
    }
}
