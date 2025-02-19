using System.Threading.Tasks;
using Wiz.Template.Application.Handlers.PaidBill;
using Wiz.Template.Application.Services;
using Wiz.Template.Infra.Clients.Pagarme;
using Wiz.Template.Infra.Mappings;

namespace Wiz.Template.Infra.Services;

public class PaidBillService : IPaidBillService
{
    private IPagarMeApi _pagarMeApi;

    public PaidBillService(IPagarMeApi pagarMeApi)
    {
        _pagarMeApi = pagarMeApi;
    }

    public async Task<PaidBillOutput> ExecuteAsync(PaidBillInput input)
    {
        BoletoPaymentRequest request = input.ToRequestPayment();
        
        await _pagarMeApi.CreateBoletoPaymentAsync(request);

        return new() { Paid = true };
    }
}
