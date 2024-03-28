using API.Controllers;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Tests.Controllers;

public class SiteControllerTests
{
    [Fact]
    public void SiteController_Get_ReturnsText()
    {
        //Arrange
        var logger = Substitute.For<ILogger<SiteController>>(); 
        var controller = new SiteController(logger);

        //Act
        var contentResult = controller.GetHelloMessage();

        // Assert
        Assert.NotNull(contentResult);
        Assert.Equal("Hello, I'm working :)", contentResult);
    }
}