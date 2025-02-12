using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using Wizco.Common.Application;
using Wizco.Common.Functions;
using Wiz.Template.Infra;

namespace Wiz.PushNotification.Function;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main()
    {
        var host = BaseProgram.ConfigureMiddleware()
         .ConfigureServices((c, s) =>
         {
             s.AddApplication();
             s.AddInfrastructure(c.Configuration);
         }).Build();

        host.Run();
    }
}