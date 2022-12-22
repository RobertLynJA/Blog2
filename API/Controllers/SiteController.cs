using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class SiteController : ControllerBase
    {
        [Route("/")]
        [HttpGet]
        public ActionResult<string> GetHelloMessage()
        {
            return Ok("Hello, I'm working :)");
        }
    }
}
