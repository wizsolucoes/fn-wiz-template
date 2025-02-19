using Wiz.Template.Application.Handlers.LibertyApoliceGenerated;

namespace Wiz.Template.Application.Services;

public interface ILibertyService
{
    Task<LibertyApoliceGeneratedOutput> GenerateApoliceAsync(LibertyApoliceGeneratedInput input);
}
