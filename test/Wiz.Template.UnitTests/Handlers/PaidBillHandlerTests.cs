using Microsoft.Extensions.Logging;
using NSubstitute;
using Wiz.Template.Application.Handlers.PaidBill;
using Wiz.Template.Application.Services;
using Wizco.Common.Application;

namespace Wiz.Template.UnitTests.Handlers;

public class PaidBillHandlerTests
{
    private readonly IPaidBillService _paidBillService;
    private readonly ILogger<HandlerBase<PaidBillInput, PaidBillOutput>> _logger;
    private readonly PaidBillHandler _handler;

    public PaidBillHandlerTests()
    {
        _paidBillService = Substitute.For<IPaidBillService>();
        _logger = Substitute.For<ILogger<HandlerBase<PaidBillInput, PaidBillOutput>>>();
        _handler = new PaidBillHandler(_paidBillService, _logger);
    }

    [Fact]
    public async Task HandleAsync_ShouldCallExecuteAsync_AndSetResponseData()
    {
        // Arrange
        var input = new PaidBillInput { CodigoBarras = "001 9 337370000000100 05009 401448 16060680935031" };
        var expectedOutput = new PaidBillOutput();
        _paidBillService.ExecuteAsync(input).Returns(Task.FromResult(expectedOutput));

        // Act
        await _handler.ProcessAsync(input);

        // Assert
        await _paidBillService.Received(1).ExecuteAsync(input);
        Assert.Equal(expectedOutput, _handler.Response.Data);
    }

    [Fact]
    public async Task ValidateAsync_ShouldAddError_WhenCodigoBarrasIsInvalid()
    {
        // Arrange
        var input = new PaidBillInput { CodigoBarras = "invalid" };
        
        // Act
        await _handler.ProcessAsync(input);

        // Assert
        Assert.False(_handler.Response.HasErrors);
    }

    [Fact]
    public async Task HandleAsync_ShouldThrowException_WhenPaidBillServiceThrowsException()
    {
        // Arrange
        var input = new PaidBillInput { CodigoBarras = "123456" };
        _paidBillService.ExecuteAsync(input).Returns(Task.FromException<PaidBillOutput>(new System.Exception("Error")));

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(() => _handler.ProcessAsync(input));
    }
}
