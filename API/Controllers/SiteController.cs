﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        return "Hello, I'm working :)";
    }

    [Route("testadmin")]
    [Authorize(Policy="Admin")]
    [HttpGet]
    public string TestAdmin()
    {
        return "Authorized Admin";
    }

    [Route("testuser")]
    [Authorize]
    [HttpGet]
    public string TestUser()
    {
        return "Authorized User";
    }
}
