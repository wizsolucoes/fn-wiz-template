using System.Threading.Tasks;
using Wiz.Template.Application.Handlers.LibertyApoliceGenerated;
using Wiz.Template.Application.Services;
using Wiz.Template.Infra.Clients.Liberty;
using Wiz.Template.Infra.Mappings;

namespace Wiz.Template.Infra.Services;

public class LibertyService : ILibertyService
{
    private readonly ILibertySegurosApi libertySegurosApi;

    public LibertyService(ILibertySegurosApi libertySegurosApi)
    {
        this.libertySegurosApi = libertySegurosApi;
    }

    public async Task<LibertyApoliceGeneratedOutput> GenerateApoliceAsync(LibertyApoliceGeneratedInput input)
    {
        var request = input.ToApoliceRequest();
        var response = await libertySegurosApi.GerarApoliceAsync(request);

        return new()
        {
            Content = response.File
        };
    }
}
