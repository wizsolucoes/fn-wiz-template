using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.AccessToken
{
    /// <summary>
    /// Runs on every request and passes the function context (e.g. Http request and host configuration) to a value provider.
    /// </summary>
    public class AccessTokenBinding : IBinding
    {
        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            DefaultHttpRequest request = context.BindingData.Values.FirstOrDefault(d => d is DefaultHttpRequest) as DefaultHttpRequest;

            string audience = Environment.GetEnvironmentVariable("wiz:sso:audience");
            string issuer = Environment.GetEnvironmentVariable("wiz:sso:issuer");

            Task<IValueProvider> valueProviderTask = Task.FromResult<IValueProvider>(new AccessTokenValueProvider(request, audience, issuer));


            return valueProviderTask;
        }

        public bool FromAttribute => true;

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context) => null;

        public ParameterDescriptor ToParameterDescriptor() => new ParameterDescriptor();
    }
}
