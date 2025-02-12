using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wiz.Template.Application.Services;
using Wiz.Template.Infra.Clients;
using Wiz.Template.Infra.Services;

namespace Wiz.Template.Infra;

public static class InfrastructureStartup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddClients(configuration);

        service.AddScoped<IPaidBillService, PaidBillService>();
        service.AddScoped<ILibertyService, LibertyService>();

        return service;
    }
}
