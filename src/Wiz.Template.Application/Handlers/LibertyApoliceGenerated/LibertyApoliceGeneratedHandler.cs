using Microsoft.Extensions.Logging;
using Wiz.Template.Application.Services;
using Wizco.Common.Application;

namespace Wiz.Template.Application.Handlers.LibertyApoliceGenerated;

public class LibertyApoliceGeneratedHandler : HandlerBase<LibertyApoliceGeneratedInput, LibertyApoliceGeneratedOutput>
{
    private ILibertyService libertyService;

    public LibertyApoliceGeneratedHandler(ILogger<HandlerBase<LibertyApoliceGeneratedInput, LibertyApoliceGeneratedOutput>> logger, ILibertyService libertyServices) : base(logger)
    {
        this.libertyService = libertyServices;
    }

    protected override async Task HandleAsync()
    {
        this.Response.Data = await libertyService.GenerateApoliceAsync(this.Input);
    }

    protected override async Task ValidateAsync()
    {
        await Task.CompletedTask;
    }
}
