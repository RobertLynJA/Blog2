using API.Controllers;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Api.Tests.Controllers;

public class SiteControllerTests
{
    [Fact]
    public void SiteController_Get_ReturnsText()
    {
        //Arrange
        var logger = new Mock<ILogger<SiteController>>();
        var controller = new SiteController(logger.Object);

        //Act
        var contentResult = controller.GetHelloMessage();

        // Assert
        Assert.NotNull(contentResult);
        Assert.Equal("Hello, I'm working :)", contentResult);
    }
}