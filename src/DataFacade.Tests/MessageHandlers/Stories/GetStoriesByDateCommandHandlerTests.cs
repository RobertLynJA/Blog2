using DataFacade.CommandHandlers.Stories;
using DataFacade.Commands.Stories;
using DataFacade.DataSource.Interfaces;
using DataFacade.Models.Stories;
using Microsoft.Extensions.Logging;

namespace DataFacade.Tests.MessageHandlers.Stories;

public class GetStoriesByDateCommandHandlerTests
{
    [Fact]
    public async Task GetStoriesByDate_ValidRange_ReturnsList()
    {
        //Arrange
        var dataSource = Substitute.For<IStoriesDataSource>(); 
        var stories = new List<Story>() { new() };
        dataSource.GetStoriesByDateAsync(0, 10, Arg.Any<CancellationToken>()).Returns(stories);

        var command = new GetStoriesByDateCommand(0, 10);

        //Act
        var result = await GetStoriesByDateCommandHandler.Handle(command, dataSource, CancellationToken.None);

        //Assert
        Assert.Equal(stories, result);
    }
}
