using Refit;
using System.Threading.Tasks;

namespace Wiz.Template.Infra.Clients.Liberty;

public interface ILibertySegurosApi
{
    [Post("/apolices")]
    Task<ApoliceResponse> GerarApoliceAsync([Body] ApoliceRequest request);
}
