using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Backend.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IStringLocalizer<RouteController> _localizer;

        public RouteController(IStringLocalizer<RouteController> sharedLocalizer)
        {
            _localizer = sharedLocalizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_localizer["The route language is {0}."].Value);
        }
    }
}
