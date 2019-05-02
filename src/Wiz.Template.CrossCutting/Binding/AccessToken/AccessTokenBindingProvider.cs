using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.AccessToken
{
    /// <summary>
    /// Fornece uma nova instância de ligação para a function em execução.
    /// </summary>
    public class AccessTokenBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = new AccessTokenBinding();

            return Task.FromResult(binding);
        }
    }
}
