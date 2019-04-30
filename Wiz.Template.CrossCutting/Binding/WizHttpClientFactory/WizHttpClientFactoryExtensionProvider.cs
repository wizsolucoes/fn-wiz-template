using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Wiz.Template.CrossCutting.Binding.WizHttpClientFactory
{
    /// <summary>
    /// Wires up the attribute to the custom binding.
    /// </summary>
    [Extension("HttpClientFactory")]
    public class WizHttpClientFactoryExtensionProvider : IExtensionConfigProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WizHttpClientFactoryExtensionProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<WizHttpClientFactoryAttribute>().Bind
                (new WizHttpClientFactoryBindingProvider(_httpClientFactory));
        }
    }
}
