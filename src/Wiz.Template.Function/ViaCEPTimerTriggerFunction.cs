using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wiz.Template.Domain.Attribute;
using Wiz.Template.Infra.Services;

namespace Wiz.Template.Function
{
    public static class ViaCEPTimerTriggerFunction
    {
        [FunctionName("ViaCEPTimerTriggerFunction")]
        [ExceptionFilter(Name = "ViaCEPTimerTriggerFunction")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"ViaCEPTimerTriggerFunction executada: {DateTime.Now}");

            var cep = "29315755";

            var endereco = await ViaCEPService.GetByCEPAsync(cep);

            log.LogInformation($"Endereço: {JsonConvert.SerializeObject(endereco)}");

            log.LogInformation($"ViaCEPTimerTriggerFunction finalizada: {DateTime.Now}");
        }
    }
}
