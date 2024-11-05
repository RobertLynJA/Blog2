using API.Controllers;
using API.Tests.TestExtensions;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute.Core.Arguments;

namespace Api.Tests.Controllers;

public class SiteControllerTests
{
    [Fact]
    public void SiteController_Get_ReturnsText()
    {
        //Arrange
        var logger = Substitute.For<ILogger<SiteController>>();
        var controller = new SiteController(logger)
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            }
        };

        //Act
        var contentResult = controller.GetHelloMessage();

        // Assert
        Assert.NotNull(contentResult);
        Assert.Equal("Hello, I'm working :)", contentResult);
        logger.Received().AnyLogOfType(LogLevel.Information);
    }
}