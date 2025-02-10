using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Wiz.Template.Function.Functions.Servicebus;

public class LibertyApoliceGeneratedFunction
{
    private readonly ILogger<LibertyApoliceGeneratedFunction> _logger;

    public LibertyApoliceGeneratedFunction(ILogger<LibertyApoliceGeneratedFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(LibertyApoliceGeneratedFunction))]
    public async Task Run(
        [ServiceBusTrigger("%Topic%", "%Subscription%", Connection = "Connection")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message ID: {id}", message.MessageId);
        _logger.LogInformation("Message Body: {body}", message.Body);
        _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

        // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }
}
