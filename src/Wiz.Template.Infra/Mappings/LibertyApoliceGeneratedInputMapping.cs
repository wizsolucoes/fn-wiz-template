using Wiz.Template.Application.Handlers.LibertyApoliceGenerated;
using Wiz.Template.Infra.Clients.Liberty;

namespace Wiz.Template.Infra.Mappings;

public static class LibertyApoliceGeneratedInputMapping
{
    public static ApoliceRequest ToApoliceRequest(this LibertyApoliceGeneratedInput paidBillInput)
    {
        return new()
        {
            CustomerId = paidBillInput.ClientId
        };
    }
}
