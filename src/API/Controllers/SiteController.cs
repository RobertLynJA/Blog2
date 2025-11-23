using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("/")]
[ApiController]
public class SiteController(ILogger<SiteController> logger) : ControllerBase
{
    private readonly ILogger<SiteController> _logger = logger;

    [HttpGet]
    public string GetHelloMessage()
    {
        _logger.LogInformation("URL: {URL}", Request.GetDisplayUrl());
        return "Hello, I'm working :)";
    }

    [Route("testadmin")]
    [Authorize(Policy="Admin")]
    [HttpGet]
    public string TestAdmin()
    {
        _logger.LogInformation("URL: {URL}", Request.GetDisplayUrl());
        return "Authorized Admin";
    }

    [Route("testuser")]
    [Authorize]
    [HttpGet]
    public string TestUser()
    {
        _logger.LogInformation("URL: {URL}", Request.GetDisplayUrl());
        return "Authorized User";
    }
}
