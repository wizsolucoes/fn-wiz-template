using Microsoft.Extensions.DependencyInjection;
using Wizco.Common.Application;

namespace Wiz.Template.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddFunctionApplication(this IServiceCollection services)
    {
        services.AddApplication();
        return services;
    }
}
