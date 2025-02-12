using System.Text.RegularExpressions;

namespace Wiz.Template.Application.Shared;

/// <summary>
/// Este codigo não foi testado. trata-se de um codigo de demonstração
/// </summary>
public static class BillValidator
{
    public static bool ValidarCodigoBarras(string codigoBarras)
    {
        // O código de barras deve ter exatamente 44 dígitos numéricos
        if (string.IsNullOrWhiteSpace(codigoBarras) || codigoBarras.Length != 44 || !codigoBarras.All(char.IsDigit))
            return false;

        // Implementar lógica de validação específica (exemplo: verificar dígitos verificadores)
        return true; // Retornar true se o código de barras estiver válido
    }

    public static bool ValidarCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = Regex.Replace(cpf, "[^0-9]", ""); // Remove caracteres não numéricos

        if (cpf.Length != 11 || cpf.Distinct().Count() == 1) // CPF não pode ter todos os dígitos iguais
            return false;

        // Cálculo dos dígitos verificadores
        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = tempCpf.Select((t, i) => (t - '0') * multiplicador1[i]).Sum();
        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCpf += digito1;
        soma = tempCpf.Select((t, i) => (t - '0') * multiplicador2[i]).Sum();
        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return cpf.EndsWith(digito1.ToString() + digito2.ToString());
    }
}
