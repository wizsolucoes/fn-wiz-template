using Microsoft.ApplicationInsights;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wiz.Template.Function.Attribute
{
    public class ExceptionFilterAttribute : FunctionExceptionFilterAttribute
    {
        public string Name { get; set; }

        public override Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            var telemetry = new TelemetryClient
            {
                InstrumentationKey = Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY")
            };

            telemetry.Context.Operation.Id = Guid.NewGuid().ToString();
            telemetry.TrackException(exceptionContext.Exception);

            exceptionContext.Logger.LogError(
            $"Function Exception: '{exceptionContext.FunctionName}" +
            $":{exceptionContext.FunctionInstanceId}" +
            $"Inner Exception: {exceptionContext.Exception.InnerException}" +
            $"Message Exception: {exceptionContext.Exception.Message}");

            exceptionContext.Logger.LogError($"Encerrada {Name}: {DateTime.Now}");
            telemetry.TrackTrace($"Encerrada {Name}: {DateTime.Now}");

            return Task.CompletedTask;
        }
    }
}
