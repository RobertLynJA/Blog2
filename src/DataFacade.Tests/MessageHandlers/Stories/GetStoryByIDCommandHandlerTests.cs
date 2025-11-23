using Castle.Core.Logging;
using DataFacade.CommandHandlers.Stories;
using DataFacade.Commands.Stories;
using DataFacade.DataSource.Interfaces;
using DataFacade.Models.Stories;
using Microsoft.Extensions.Logging;

namespace DataFacade.Tests.MessageHandlers.Stories;

public class GetStoryByIdCommandHandlerTests
{
    [Fact]
    public async Task GetStoryByID_InvalidID_ReturnsNull()
    {
        //Arrange
        var dataSource = Substitute.For<IStoriesDataSource>();

        var command = new GetStoryByIdCommand("invalidID");

        //Act
        var result = await GetStoryByIdCommandHandler.Handle(command, dataSource, CancellationToken.None);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetStoryByID_ValidID_ReturnsStory()
    {
        //Arrange
        var dataSource = Substitute.For<IStoriesDataSource>();
        var story = new Story() { Id = "ID" };

        dataSource.GetStoryAsync(story.Id, Arg.Any<CancellationToken>()).Returns(story);

        var command = new GetStoryByIdCommand(story.Id);

        //Act
        var result = await GetStoryByIdCommandHandler.Handle(command, dataSource, CancellationToken.None);

        //Assert
        Assert.Equal(story, result);
    }
}
