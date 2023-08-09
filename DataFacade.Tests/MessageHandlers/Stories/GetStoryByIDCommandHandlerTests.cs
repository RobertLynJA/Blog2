using Castle.Core.Logging;
using DataFacade.CommandHandlers.Stories;
using DataFacade.Commands.Stories;
using DataFacade.DataSource.Interfaces;
using DataFacade.Models.Stories;
using Microsoft.Extensions.Logging;

namespace DataFacade.Tests.MessageHandlers.Stories;

public class GetStoryByIDCommandHandlerTests
{
    [Fact]
    public async void GetStoryByID_InvalidID_ReturnsNull()
    {
        //Arrange
        var logger = Substitute.For<ILogger<GetStoryByIDCommandHandler>>();
        var dataSource = Substitute.For<IStoriesDataSource>();

        var command = new GetStoryByIDCommand("invalidID");
        var handler = new GetStoryByIDCommandHandler(logger, dataSource);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async void GetStoryByID_ValidID_ReturnsStory()
    {
        //Arrange
        var logger = Substitute.For<ILogger<GetStoryByIDCommandHandler>>();
        var dataSource = Substitute.For<IStoriesDataSource>();
        var story = new Story() { ID = "ID" };

        dataSource.GetStoryAsync(story.ID, Arg.Any<CancellationToken>()).Returns(story);

        var command = new GetStoryByIDCommand(story.ID);
        var handler = new GetStoryByIDCommandHandler(logger, dataSource);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.Equal(story, result);
    }
}
