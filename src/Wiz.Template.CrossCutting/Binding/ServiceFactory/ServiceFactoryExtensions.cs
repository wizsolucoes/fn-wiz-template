using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wiz.Template.Domain.Interfaces.Services;
using Wiz.Template.Infra.Services;

namespace Wiz.Template.CrossCutting.Binding.ServiceFactory
{
    /// <summary>
    /// Uma chamada para carregar o mapeamento das interfaces e suas classes concretas quando o host do Azure Functions é inicializado.
    /// </summary>
    public static class ServiceFactoryExtensions
    {
        public static IWebJobsBuilder AddIoC(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IViaCEPService, ViaCEPService>();

            builder.AddExtension(new ServiceFactoryExtensionProvider(services.BuildServiceProvider()));

            return builder;
        }
    }
}
