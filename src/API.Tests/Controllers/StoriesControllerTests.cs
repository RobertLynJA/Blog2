using API.Controllers;
using API.Models.Stories;
using API.Tests.TestExtensions;
using Wolverine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Tests.Controllers;

public class StoriesControllerTests
{
    private static StoriesController CreateController(IMessageBus bus, ILogger<StoriesController> logger)
    {
        var controller = new StoriesController(logger, bus)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };

        // ensure GetDisplayUrl has something sensible
        controller.HttpContext.Request.Scheme = "http";
        controller.HttpContext.Request.Host = new HostString("localhost");
        controller.HttpContext.Request.Path = "/api/stories";

        return controller;
    }

    [Fact]
    public async Task StoriesController_Get_ReturnsOkWithMappedStories()
    {
        // Arrange
        var logger = Substitute.For<ILogger<StoriesController>>();
        var bus = Substitute.For<IMessageBus>();

        var daoStories = new List<DataFacade.Models.Stories.Story>
        {
            new() { Id = "1", Title = "Title 1", Content = "Content 1", PublishedDate = new DateTime(2024, 1, 2) },
            new() { Id = "2", Title = "Title 2", Content = "Content 2", PublishedDate = new DateTime(2024, 3, 4) }
        } as IReadOnlyList<DataFacade.Models.Stories.Story>;

        bus
            .InvokeAsync<IReadOnlyList<DataFacade.Models.Stories.Story>>(Arg.Any<DataFacade.Commands.Stories.GetStoriesByDateCommand>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(daoStories));

        var controller = CreateController(bus, logger);

        // Act
        var actionResult = await controller.Get(CancellationToken.None);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(actionResult.Result);
        var resultList = Assert.IsType<List<Story>>(ok.Value);
        Assert.Equal(2, resultList.Count);
        Assert.Collection(resultList,
            s =>
            {
                Assert.Equal("1", s.Id);
                Assert.Equal("Title 1", s.Title);
                Assert.Equal("Content 1", s.Content);
                Assert.Equal(new DateTime(2024, 1, 2), s.PublishedDate);
            },
            s =>
            {
                Assert.Equal("2", s.Id);
                Assert.Equal("Title 2", s.Title);
                Assert.Equal("Content 2", s.Content);
                Assert.Equal(new DateTime(2024, 3, 4), s.PublishedDate);
            }
        );

        logger.Received().AnyLogOfType(LogLevel.Information);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task StoriesController_GetById_ReturnsNotFound_WhenIdNullOrEmpty(string? id)
    {
        // Arrange
        var logger = Substitute.For<ILogger<StoriesController>>();
        var bus = Substitute.For<IMessageBus>();
        var controller = CreateController(bus, logger);

        // Act
        var actionResult = await controller.Get(id!, CancellationToken.None);

        // Assert
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }

    [Fact]
    public async Task StoriesController_GetById_ReturnsNotFound_WhenMediatorReturnsNull()
    {
        // Arrange
        var logger = Substitute.For<ILogger<StoriesController>>();
        var bus = Substitute.For<IMessageBus>();

        bus
            .InvokeAsync<DataFacade.Models.Stories.Story?>(Arg.Any<DataFacade.Commands.Stories.GetStoryByIdCommand>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult<DataFacade.Models.Stories.Story?>(null));

        var controller = CreateController(bus, logger);

        // Act
        var actionResult = await controller.Get("abc", CancellationToken.None);

        // Assert
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }

    [Fact]
    public async Task StoriesController_GetById_ReturnsOkWithMappedStory()
    {
        // Arrange
        var logger = Substitute.For<ILogger<StoriesController>>();
        var bus = Substitute.For<IMessageBus>();

        var dao = new DataFacade.Models.Stories.Story
        {
            Id = "xyz",
            Title = "My Title",
            Content = "My Content",
            PublishedDate = new DateTime(2023, 5, 6)
        };

        bus
            .InvokeAsync<DataFacade.Models.Stories.Story?>(Arg.Any<DataFacade.Commands.Stories.GetStoryByIdCommand>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult<DataFacade.Models.Stories.Story?>(dao));

        var controller = CreateController(bus, logger);

        // Act
        var actionResult = await controller.Get("xyz", CancellationToken.None);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(actionResult.Result);
        var story = Assert.IsType<Story>(ok.Value);
        Assert.Equal("xyz", story.Id);
        Assert.Equal("My Title", story.Title);
        Assert.Equal("My Content", story.Content);
        Assert.Equal(new DateTime(2023, 5, 6), story.PublishedDate);

        logger.Received().AnyLogOfType(LogLevel.Information);
    }
}