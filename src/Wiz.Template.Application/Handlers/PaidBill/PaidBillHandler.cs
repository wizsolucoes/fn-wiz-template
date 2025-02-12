using Microsoft.Extensions.Logging;
using Wiz.Template.Application.Services;
using Wiz.Template.Application.Shared;
using Wizco.Common.Application;

namespace Wiz.Template.Application.Handlers.PaidBill;

public class PaidBillHandler : HandlerBase<PaidBillInput, PaidBillOutput>
{
    private readonly IPaidBillService paidBillService;

    public PaidBillHandler(
        IPaidBillService paidBillService,
        ILogger<HandlerBase<PaidBillInput, PaidBillOutput>> logger) : base(logger)
    {
        this.paidBillService = paidBillService;
    }

    protected override async Task HandleAsync()
    {
        Response.Data = await paidBillService.ExecuteAsync(Input);
    }

    protected override async Task ValidateAsync()
    {
        if (BillValidator.ValidarCodigoBarras(Input.CodigoBarras))
        {
            Response.AddError("Codigo de barras invalido para pagmento.");
        }

        await Task.CompletedTask;
    }
}
