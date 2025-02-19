using Wiz.Template.Application.Handlers.PaidBill;

namespace Wiz.Template.Application.Services
{
    public interface IPaidBillService
    {
        Task<PaidBillOutput> ExecuteAsync(PaidBillInput input);
    }
}
