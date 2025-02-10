using System.Threading.Tasks;
using Wiz.Template.Application.Handlers.PaidBill;
using Wiz.Template.Application.Services;

namespace Wiz.Template.Infra.Services;

public class PaidBillService : IPaidBillService
{
    public Task<PaidBillOutput> ExecuteAsync(PaidBillInput input)
    {
        throw new System.NotImplementedException();
    }
}
