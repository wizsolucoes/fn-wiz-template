namespace Wiz.Template.Application.Handlers.PaidBill;

public class PaidBillInput
{
    /// <summary>
    /// Gets or sets the numero documento.
    /// </summary>
    /// <value>
    /// The numero documento.
    /// </value>
    public string NumeroDocumento { get; set; }

    /// <summary>
    /// Gets or sets the codigo barras.
    /// </summary>
    /// <value>
    /// The codigo barras.
    /// </value>
    public string CodigoBarras { get; set; }

    /// <summary>
    /// Gets or sets the linha digitavel.
    /// </summary>
    /// <value>
    /// The linha digitavel.
    /// </value>
    public string LinhaDigitavel { get; set; }

    /// <summary>
    /// Gets or sets the valor.
    /// </summary>
    /// <value>
    /// The valor.
    /// </value>
    public decimal Valor { get; set; }

    /// <summary>
    /// Gets or sets the data vencimento.
    /// </summary>
    /// <value>
    /// The data vencimento.
    /// </value>
    public DateTime DataVencimento { get; set; }

    /// <summary>
    /// Gets or sets the nome beneficiario.
    /// </summary>
    /// <value>
    /// The nome beneficiario.
    /// </value>
    public string NomeBeneficiario { get; set; }

    /// <summary>
    /// Gets or sets the CNPJ beneficiario.
    /// </summary>
    /// <value>
    /// The CNPJ beneficiario.
    /// </value>
    public string CnpjBeneficiario { get; set; }

    /// <summary>
    /// Gets or sets the nome pagador.
    /// </summary>
    /// <value>
    /// The nome pagador.
    /// </value>
    public string NomePagador { get; set; }

    /// <summary>
    /// Gets or sets the CPF CNPJ pagador.
    /// </summary>
    /// <value>
    /// The CPF CNPJ pagador.
    /// </value>
    public string CpfCnpjPagador { get; set; }

    /// <summary>
    /// Gets or sets the banco emissor.
    /// </summary>
    /// <value>
    /// The banco emissor.
    /// </value>
    public string BancoEmissor { get; set; }
}