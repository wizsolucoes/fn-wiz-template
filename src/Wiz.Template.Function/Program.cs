using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using Wizco.Common.Functions;

namespace Wiz.PushNotification.Function;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main()
    {
        var host = BaseProgram.ConfigureMiddleware()
         .ConfigureServices((c, s) =>
         {
             s.AddPushNotificationApplication();
             s.AddInfrastructure();
         }).Build();

        host.Run();
    }
}