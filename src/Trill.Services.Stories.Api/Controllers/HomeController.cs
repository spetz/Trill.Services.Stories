using Convey.Types;
using Microsoft.AspNetCore.Mvc;

namespace Trill.Services.Stories.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private readonly AppOptions _appOptions;

        public HomeController(AppOptions appOptions)
        {
            _appOptions = appOptions;
        }

        [HttpGet]
        public ActionResult<string> Get() => _appOptions.Name;
    }
}