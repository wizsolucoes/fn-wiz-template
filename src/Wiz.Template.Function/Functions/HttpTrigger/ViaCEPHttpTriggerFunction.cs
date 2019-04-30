using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Security.Claims;
using Wiz.Template.CrossCutting.Binding.AccessToken;
using Wiz.Template.CrossCutting.Binding.WizHttpClientFactory;
using System.Net.Http;

namespace Wiz.Template.Function.Functions.HttpTrigger
{
    public static class ViaCEPHttpTriggerFunction
    {
        [FunctionName("ViaCEPHttpTriggerFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [AccessToken] ClaimsPrincipal user,
            [WizHttpClientFactory(WizHttpClientOptions.WizCross)] HttpClient httpClientCross,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;


            if (user?.Identity.IsAuthenticated == true)
            {
                //Chama um serviço interno passando o AccessToken para esse serviço interno
                HttpResponseMessage msg = await httpClientCross.GetAsync("https://domain-de-servico-autenticado");


                return name != null
                        ? (ActionResult)new OkObjectResult($"Hello, {user?.Identity.Name} (Autenticado info do token)")
                        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }
            else
            {
                return name != null
                        ? (ActionResult)new OkObjectResult($"Hello, {name} (não autenticado)")
                        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }
        }
    }
}
