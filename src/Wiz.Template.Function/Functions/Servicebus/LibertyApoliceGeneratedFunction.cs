using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Wiz.Template.Application.Handlers.LibertyApoliceGenerated;

namespace Wiz.Template.Function.Functions.Servicebus;

public class LibertyApoliceGeneratedFunction
{
    private readonly ILogger<LibertyApoliceGeneratedFunction> _logger;
    private LibertyApoliceGeneratedHandler handler;

    public LibertyApoliceGeneratedFunction(ILogger<LibertyApoliceGeneratedFunction> logger, LibertyApoliceGeneratedHandler handler)
    {
        _logger = logger;
        this.handler = handler;
    }

    [Function(nameof(LibertyApoliceGeneratedFunction))]
    public async Task Run(
        [ServiceBusTrigger("%Topic%", "%Subscription%", Connection = "Connection")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        LibertyApoliceGeneratedInput input = JsonSerializer.Deserialize<LibertyApoliceGeneratedInput>(message.Body);
        await handler.ProcessAsync(input);

         // Complete the message
         await messageActions.CompleteMessageAsync(message);
    }
}
