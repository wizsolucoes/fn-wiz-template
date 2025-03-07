using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Wiz.Template.Function.Functions.Timers;

/// <summary>
/// Avaliar apolices de seguro vencidas
/// </summary>
public class InsurancePolicyChecker
{
    private readonly ILogger _logger;

    public InsurancePolicyChecker(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<InsurancePolicyChecker>();
    }

    [Function("InsurancePolicyChecker")]
    public void Run([TimerTrigger("0 0 3 * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        
        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }
}
