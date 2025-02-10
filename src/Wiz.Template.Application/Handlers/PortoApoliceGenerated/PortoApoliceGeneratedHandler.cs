using Microsoft.Extensions.Logging;
using Wizco.Common.Application;

namespace Wiz.Template.Application.Handlers.PortoApoliceGenerated;

public class PortoApoliceGeneratedHandler : HandlerBase<PortoApoliceGeneratedInput, PortoApoliceGeneratedOutput>
{
    public PortoApoliceGeneratedHandler(ILogger<HandlerBase<PortoApoliceGeneratedInput, PortoApoliceGeneratedOutput>> logger) : base(logger)
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
