using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.WizHttpClientFactory
{
    /// <summary>
    /// Provides a new binding instance for the function host.
    /// </summary>
    public class WizHttpClientFactoryBindingProvider : IBindingProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WizHttpClientFactoryBindingProvider(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {

            WizHttpClientOptions option = (context.Parameter.GetCustomAttributes(false)[0] as WizHttpClientFactoryAttribute).Option;

            IBinding binding = new WizHttpClientFactoryBinding(option, _httpClientFactory);
            return Task.FromResult(binding);
        }
    }

}
