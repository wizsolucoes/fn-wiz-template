using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.WizHttpClientFactory
{
    /// <summary>
    /// Runs on every request and passes the function context (e.g. Http request and host configuration) to a value provider.
    /// </summary>
    public class WizHttpClientFactoryBinding : IBinding
    {
        private readonly WizHttpClientOptions _option;
        private readonly IHttpClientFactory _httpClientFactory;

        public WizHttpClientFactoryBinding(WizHttpClientOptions option, IHttpClientFactory httpClientFactory)
        {
            this._option = option;
            this._httpClientFactory = httpClientFactory;
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            DefaultHttpRequest request = context.BindingData.Values.FirstOrDefault(d => d is DefaultHttpRequest) as DefaultHttpRequest;

            Task<IValueProvider> valueProviderTask = Task.FromResult<IValueProvider>(new WizHttpClientFactoryValueProvider(_option, request, _httpClientFactory));

            return valueProviderTask;
        }

        public bool FromAttribute => true;

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context) => null;

        public ParameterDescriptor ToParameterDescriptor() => new ParameterDescriptor();
    }
}
