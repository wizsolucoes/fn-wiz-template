using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Wiz.Template.Domain.Attribute;
using Wiz.Template.Infra.Services;
using Newtonsoft.Json;

namespace Wiz.Template.Function
{
    public static class ViaCEPHttpTriggerFunction
    {
        [FunctionName("ViaCEPHttpTriggerFunction")]
        [ExceptionFilter(Name = "ViaCEPHttpTriggerFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/cep")] HttpRequest req, ILogger log)
        {
            log.LogInformation($"ViaCEPHttpTriggerFunction executada: {DateTime.Now}");

            var cep = req.Query["cep"];

            var endereco = await ViaCEPService.GetByCEPAsync(cep);

            log.LogInformation($"ViaCEPHttpTriggerFunction finalizada: {DateTime.Now}");

            return new OkObjectResult(JsonConvert.SerializeObject(endereco));
        }
    }
}
