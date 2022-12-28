using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        [HttpGet]
        public string GetHelloMessage()
        {
            return "Hello, I'm working :)";
        }
    }
}
