using System;

namespace Wiz.Template.Infra.Clients.Pagarme;

public class BoletoPaymentRequest
{
    public decimal Amount { get; set; } // Valor em centavos (ex: R$ 100,00 = 10000)
    public string PaymentMethod { get; set; } = "boleto"; // Define que o pagamento é via boleto
    public Boleto Boleto { get; set; }
    public Customer Customer { get; set; }
}

public class Boleto
{
    public DateTime DueDate { get; set; } // Data de vencimento do boleto (yyyy-MM-dd)
    public string Instructions { get; set; } // Instruções para o boleto
}

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Type { get; set; } = "individual"; // individual ou company
    public string Document { get; set; } // CPF ou CNPJ
}
