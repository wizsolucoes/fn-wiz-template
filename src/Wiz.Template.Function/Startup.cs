using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Wiz.Template.CrossCutting.Binding.AccessToken;
using Wiz.Template.CrossCutting.Binding.ServiceFactory;
using Wiz.Template.CrossCutting.Binding.WizHttpClientFactory;
using Wiz.Template.Function;

[assembly: WebJobsStartup(typeof(Startup))]
namespace Wiz.Template.Function
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            //Adiciona a injeção de dependencia no Azure function
            //Observe a classe ServiceFactoryExtensions para poder adicionar outros serviços
            //[ServiceFactory] IViaCEPService serviceCep
            builder.AddIoC();

            //Injeta um objeto do tipo HttpClient já configurado para ser resiliente e pegar o token de acesso que foi enviado pelo client
            //[WizHttpClientFactory(WizHttpClientOptions.WizCross)] HttpClient httpClientCross
            builder.AddHttpClientBinding();

            //Injeto um objeto do tipo ClaimsPrincipal já com as informações de que esta autenticado
            // [AccessToken] ClaimsPrincipal user
            builder.AddAccessTokenBinding();
        }
    }

}
