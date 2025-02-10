using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Wiz.Template.Function.Functions;

public class PaidBillServiceBusFunction
{
    private readonly ILogger<PaidBillServiceBusFunction> _logger;

    public PaidBillServiceBusFunction(ILogger<PaidBillServiceBusFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(PaidBillServiceBusFunction))]
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
