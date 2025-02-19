using NSubstitute;
using Wiz.Template.Application.Handlers.LibertyApoliceGenerated;
using Wiz.Template.Infra.Clients.Liberty;
using Wiz.Template.Infra.Services;

namespace Wiz.Template.UnitTests.Services;

public class LibertyServiceTests
{
    private readonly ILibertySegurosApi _libertySegurosApi;
    private readonly LibertyService _libertyService;

    public LibertyServiceTests()
    {
        _libertySegurosApi = Substitute.For<ILibertySegurosApi>();
        _libertyService = new LibertyService(_libertySegurosApi);
    }

    [Fact]
    public async Task GenerateApoliceAsync_ShouldCallGerarApoliceAsync_AndReturnExpectedOutput()
    {
        // Arrange
        var input = new LibertyApoliceGeneratedInput() { ClientId = 10 };
        var request = new ApoliceRequest();
        var expectedResponse = new ApoliceResponse { File = "GeneratedFile" };
        var expectedOutput = new LibertyApoliceGeneratedOutput { Content = "GeneratedFile" };

        _libertySegurosApi.GerarApoliceAsync(Arg.Any<ApoliceRequest>()).Returns(Task.FromResult(expectedResponse));

        // Act
        var result = await _libertyService.GenerateApoliceAsync(input);

        // Assert
        await _libertySegurosApi.Received(1).GerarApoliceAsync(Arg.Any<ApoliceRequest>());
        Assert.Equal(expectedOutput.Content, result.Content);
    }

    [Fact]
    public async Task GenerateApoliceAsync_ShouldThrowException_WhenApiThrowsException()
    {
        // Arrange
        var input = new LibertyApoliceGeneratedInput() { ClientId = 10 };
        var request = new ApoliceRequest();
        _libertySegurosApi.GerarApoliceAsync(Arg.Any<ApoliceRequest>()).Returns(Task.FromException<ApoliceResponse>(new System.Exception("API Error")));

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(() => _libertyService.GenerateApoliceAsync(input));
    }
}
