using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class SiteController : ControllerBase
    {
        [Route("/")]
        [HttpGet]
        public string GetHelloMessage()
        {
            return "Hello, I'm working :)";
        }
    }
}
