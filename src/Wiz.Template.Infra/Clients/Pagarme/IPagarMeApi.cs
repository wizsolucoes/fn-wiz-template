using Refit;
using System.Threading.Tasks;

namespace Wiz.Template.Infra.Clients.Pagarme;

public interface IPagarMeApi
{
    [Headers("Authorization: Basic")]
    [Post("/transactions")]
    Task<ApiResponse<dynamic>> CreateBoletoPaymentAsync([Body] BoletoPaymentRequest request);
}
