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
    /// Called from Startup to load the custom binding when the Azure Functions host starts up.
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
