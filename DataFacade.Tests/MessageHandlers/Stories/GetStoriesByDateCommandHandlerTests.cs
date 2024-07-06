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
        var logger = Substitute.For<ILogger<GetStoriesByDateCommandHandler>>(); 
        var dataSource = Substitute.For<IStoriesDataSource>(); 
        var stories = new List<Story>();
        dataSource.GetStoriesByDateAsync(0, 10, Arg.Any<CancellationToken>()).Returns(stories);

        var command = new GetStoriesByDateCommand(0, 10);
        var handler = new GetStoriesByDateCommandHandler(logger, dataSource);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.Equal(stories, result);
    }
}
