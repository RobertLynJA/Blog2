using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests.Controllers
{
    public class SiteControllerTests
    {
        [Fact]
        public void SiteController_Get_ReturnsText()
        {
            //Arrange
            var controller = new SiteController();

            //Act
            var actionResult = controller.GetHelloMessage();
            var contentResult = actionResult.Result as OkObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal("Hello, I'm working :)", contentResult.Value);
        }
    }
}