using Wiz.Template.Application.Handlers.PaidBill;
using Wiz.Template.Infra.Clients.Pagarme;

namespace Wiz.Template.Infra.Mappings;

public static class PaidBillInputMappings
{
    public static BoletoPaymentRequest ToRequestPayment(this PaidBillInput paidBillInput)
    {
        return new()
        {
            Amount = paidBillInput.Valor,
            PaymentMethod = "PA",
            Boleto = new Boleto { DueDate = paidBillInput.DataVencimento },
            Customer = new Customer { Name = paidBillInput.NomePagador }
        };
    }
}
