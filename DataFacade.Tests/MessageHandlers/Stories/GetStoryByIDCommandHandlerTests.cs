﻿using Castle.Core.Logging;
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
        var logger = new Mock<ILogger<GetStoryByIDCommandHandler>>();
        var dataSource = new Mock<IStoriesDataSource>();

        var command = new GetStoryByIDCommand("invalidID");
        var handler = new GetStoryByIDCommandHandler(logger.Object, dataSource.Object);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async void GetStoryByID_ValidID_ReturnsStory()
    {
        //Arrange
        var logger = new Mock<ILogger<GetStoryByIDCommandHandler>>();
        var dataSource = new Mock<IStoriesDataSource>();
        var story = new Story() { ID = "ID" };
        dataSource.Setup(d => d.GetStoryAsync(story.ID, It.IsAny<CancellationToken>())).ReturnsAsync(story);

        var command = new GetStoryByIDCommand(story.ID);
        var handler = new GetStoryByIDCommandHandler(logger.Object, dataSource.Object);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.Equal(story, result);
    }
}