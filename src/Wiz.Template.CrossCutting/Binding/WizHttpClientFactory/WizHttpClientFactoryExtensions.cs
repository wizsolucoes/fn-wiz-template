using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Polly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Wiz.Template.CrossCutting.Binding.WizHttpClientFactory
{
    /// <summary>
    /// Uma chamada para carregar o as regras do HttpClient já com políticas predefinidas a partir do momento em que o host do Azure Functions é inicializado.
    /// </summary>
    public static class WizHttpClientFactoryExtensions
    {
        public static IWebJobsBuilder AddHttpClientBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<WizHttpClientFactoryExtensionProvider>();

            ConfigureHttpWizCross(builder);
            ConfigureHttpDefault(builder);

            return builder;
        }

        private static void ConfigureHttpWizCross(IWebJobsBuilder builder)
        {
            builder.Services.AddHttpClient("WizCross").ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            })
            .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.OrResult(response =>
                 (int)response.StatusCode == (int)HttpStatusCode.Forbidden)
            .WaitAndRetryAsync(3, retry =>
                TimeSpan.FromSeconds(Math.Pow(2, retry)) +
                TimeSpan.FromMilliseconds(new Random().Next(0, 100))))
            .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(
                 handledEventsAllowedBeforeBreaking: 3,
                 durationOfBreak: TimeSpan.FromSeconds(30)
             ));

            builder.Services.Configure<HttpClientFactoryOptions>("WizCross", options => options.SuppressHandlerScope = true);
        }

        private static void ConfigureHttpDefault(IWebJobsBuilder builder)
        {
            builder.Services.AddHttpClient("Outro").ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            })
            .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.OrResult(response =>
                 (int)response.StatusCode == (int)HttpStatusCode.Forbidden)
            .WaitAndRetryAsync(3, retry =>
                TimeSpan.FromSeconds(Math.Pow(2, retry)) +
                TimeSpan.FromMilliseconds(new Random().Next(0, 100))))
            .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(
                 handledEventsAllowedBeforeBreaking: 3,
                 durationOfBreak: TimeSpan.FromSeconds(30)
             ));

            builder.Services.Configure<HttpClientFactoryOptions>("Outro", options => options.SuppressHandlerScope = true);
        }
    }
}
