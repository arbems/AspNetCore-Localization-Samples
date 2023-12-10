using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        [HttpGet("GetLanguage")]
        public IActionResult GetLanguage()
        {
            var currentLanguage = HttpContext.Features.Get<IRequestCultureFeature>()?
                .RequestCulture.Culture.Name;

            return Ok(currentLanguage);
        }

        [HttpPost("SetLanguage")]
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return Ok();
        }

        [HttpDelete("ClearLanguage")]
        public IActionResult ClearLanguage()
        {
            Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
            return Ok();
        }
    }
}
