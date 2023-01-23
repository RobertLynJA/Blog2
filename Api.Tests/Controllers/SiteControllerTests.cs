using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests.Controllers;

public class SiteControllerTests
{
    [Fact]
    public void SiteController_Get_ReturnsText()
    {
        //Arrange
        var controller = new SiteController();

        //Act
        var contentResult = controller.GetHelloMessage();

        // Assert
        Assert.NotNull(contentResult);
        Assert.Equal("Hello, I'm working :)", contentResult);
    }
}