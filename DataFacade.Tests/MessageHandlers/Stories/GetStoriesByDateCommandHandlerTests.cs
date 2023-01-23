using DataFacade.CommandHandlers.Stories;
using DataFacade.Commands.Stories;
using DataFacade.DataSource.Interfaces;
using DataFacade.Models.Stories;
using Microsoft.Extensions.Logging;

namespace DataFacade.Tests.MessageHandlers.Stories;

public class GetStoriesByDateCommandHandlerTests
{
    [Fact]
    public async void GetStoriesByDate_ValidRange_ReturnsList()
    {
        //Arrange
        var logger = new Mock<ILogger<GetStoriesByDateCommandHandler>>();
        var dataSource = new Mock<IStoriesDataSource>();
        var stories = new List<Story>();
        dataSource.Setup(d => d.GetStoriesByDateAsync(0, 10, new CancellationToken()))
            .ReturnsAsync(stories);

        var command = new GetStoriesByDateCommand(0, 10);
        var handler = new GetStoriesByDateCommandHandler(logger.Object, dataSource.Object);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.Equal(stories, result);
    }
}
