using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Net.Http;
using System;
using Wiz.Template.Infra.Clients.Pagarme;
using Microsoft.Extensions.Configuration;
using Wiz.Template.Infra.Clients.Liberty;

namespace Wiz.Template.Infra.Clients;

public static class ClientsStartup
{
    public static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        ////Codigos de demonstração. para se conectar a uma seguradora ou qualquer outro tipo de integração, consulte a documentação do fornecedor.
        
        string apiKey = configuration["WPRO:Pagarme:Key"]; // Substitua pela sua chave de API do Pagar.me

        var pagarMeApi = RestService.For<IPagarMeApi>(
            new HttpClient
            {
                //"https://api.pagar.me/core/v5/"
                BaseAddress = new Uri(configuration["WPRO:Pagarme:Key"])
            }
        );

        ///"https://api.libertyseguros.com.br"
        RestService.For<ILibertySegurosApi>(configuration["WPRO:LibertySeguros:Key"]);

        return services;
    }
}
