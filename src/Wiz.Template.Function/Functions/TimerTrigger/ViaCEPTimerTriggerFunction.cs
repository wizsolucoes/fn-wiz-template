using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wiz.Template.CrossCutting.Binding.ServiceFactory;
using Wiz.Template.Domain.Interfaces.Services;

namespace Wiz.Template.Function.Functions.TimerTrigger
{
    public static class ViaCEPTimerTriggerFunction
    {
        [FunctionName("ViaCEPTimerTriggerFunction")]
        //[ExceptionFilter(Name = "ViaCEPTimerTriggerFunction")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, [ServiceFactory] IViaCEPService serviceCep, ILogger log)
        {
            log.LogInformation($"ViaCEPTimerTriggerFunction executada: {DateTime.Now}");

            var cep = "29315755";

            var endereco = await serviceCep.GetByCEPAsync(cep);

            log.LogInformation($"Endereço: {JsonConvert.SerializeObject(endereco)}");

            log.LogInformation($"ViaCEPTimerTriggerFunction finalizada: {DateTime.Now}");
        }
    }
}
