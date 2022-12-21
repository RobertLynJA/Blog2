using API.Controllers;

namespace Api.Tests.Controllers
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var controller = new SiteController();

            var result = controller.GetHelloMessage();

            Assert.Equal("Hello, I'm working :)", result);
        }
    }
}