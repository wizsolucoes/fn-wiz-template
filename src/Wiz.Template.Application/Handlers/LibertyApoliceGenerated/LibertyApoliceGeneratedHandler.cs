using Microsoft.Extensions.Logging;
using Wizco.Common.Application;

namespace Wiz.Template.Application.Handlers.LibertyApoliceGenerated;

public class LibertyApoliceGeneratedHandler : HandlerBase<LibertyApoliceGeneratedInput, LibertyApoliceGeneratedOutput>
{
    public LibertyApoliceGeneratedHandler(ILogger<HandlerBase<LibertyApoliceGeneratedInput, LibertyApoliceGeneratedOutput>> logger) : base(logger)
    {
    }

    protected override Task HandleAsync()
    {
        throw new NotImplementedException();
    }

    protected override Task ValidateAsync()
    {
        throw new NotImplementedException();
    }
}
