using Microsoft.Extensions.Logging;
using NSubstitute;
using Wiz.Template.Application.Handlers.LibertyApoliceGenerated;
using Wiz.Template.Application.Services;
using Wizco.Common.Application;

namespace Wiz.Template.UnitTests.Handlers;

public class LibertyApoliceGeneratedHandlerTests
{
    private readonly ILibertyService _libertyService;
    private readonly ILogger<HandlerBase<LibertyApoliceGeneratedInput, LibertyApoliceGeneratedOutput>> _logger;
    private readonly LibertyApoliceGeneratedHandler _handler;

    public LibertyApoliceGeneratedHandlerTests()
    {
        _libertyService = Substitute.For<ILibertyService>();
        _logger = Substitute.For<ILogger<HandlerBase<LibertyApoliceGeneratedInput, LibertyApoliceGeneratedOutput>>>();
        _handler = new LibertyApoliceGeneratedHandler(_logger, _libertyService);
    }

    [Fact]
    public async Task HandleAsync_ShouldCallGenerateApoliceAsync_AndSetResponseData()
    {
        // Arrange
        var input = new LibertyApoliceGeneratedInput();
        var expectedOutput = new LibertyApoliceGeneratedOutput();
        _libertyService.GenerateApoliceAsync(input).Returns(Task.FromResult(expectedOutput));

        // Act
        await _handler.ProcessAsync(input);

        // Assert
        await _libertyService.Received(1).GenerateApoliceAsync(input);
        Assert.Equal(expectedOutput, _handler.Response.Data);
    }

    [Fact]
    public async Task ValidateAsync_ShouldCompleteSuccessfully()
    {
        // Act
        var exception = await Record.ExceptionAsync(() => _handler.ProcessAsync());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public async Task HandleAsync_ShouldThrowException_WhenLibertyServiceThrowsException()
    {
        // Arrange
        var input = new LibertyApoliceGeneratedInput();
        _libertyService.GenerateApoliceAsync(input).Returns(Task.FromException<LibertyApoliceGeneratedOutput>(new System.Exception("Error")));

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(() => _handler.ProcessAsync(input));
    }
}
