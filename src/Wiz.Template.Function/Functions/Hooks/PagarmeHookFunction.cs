using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Wiz.Template.Application.Handlers.PaidBill;
using Wizco.Common.Base;

namespace Wiz.Template.Function.Functions.Hooks
{
    /// <summary>
    /// Usar Azure Functions com HttpTrigger para criar um webhook pode ser uma boa prática, mas depende do cenário.
    /// Temos alguma explicação aqui:
    /// 
    /// https://dev.azure.com/wizsolucoes/WizCross/_wiki/wikis/WizCross.wiki/13573/Functions
    /// </summary>
    public class PagarmeHookFunction
    {
        private readonly PaidBillHandler paidBillHandler;
        private readonly ILogger<PagarmeHookFunction> _logger;

        public PagarmeHookFunction(
            PaidBillHandler paidBillHandler,
            ILogger<PagarmeHookFunction> logger)
        {
            this.paidBillHandler = paidBillHandler;
            _logger = logger;
        }

        [Function("PagarmeHookFunction")]
        public async Task<IServiceResponse<PaidBillOutput>> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            PaidBillInput input = JsonConvert.DeserializeObject<PaidBillInput>(requestBody);

            return await paidBillHandler.ProcessAsync(input);
        }
    }
}
