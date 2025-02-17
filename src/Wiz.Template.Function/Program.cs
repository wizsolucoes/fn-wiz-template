using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using Wizco.Common.Functions;
using Wiz.Template.Infra;
using Wiz.Template.Application;

namespace Wiz.PushNotification.Function;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main()
    {
        var host = BaseProgram.ConfigureMiddleware()
         .ConfigureServices((c, s) =>
         {
             s.AddFunctionApplication();
             s.AddInfrastructure(c.Configuration);
         }).Build();

        host.Run();
    }
}