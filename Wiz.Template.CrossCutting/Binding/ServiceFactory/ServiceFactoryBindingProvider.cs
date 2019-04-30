using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.ServiceFactory
{
    /// <summary>
    /// Fornece uma nova instância de ligação para a function em execução.
    /// </summary>
    public class ServiceFactoryBindingProvider : IBindingProvider
    {
        private readonly IServiceProvider _container;

        public ServiceFactoryBindingProvider(IServiceProvider container)
        {
            this._container = container;
        }


        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = new ServiceFactoryBinding(this._container, context.Parameter.ParameterType);

            return Task.FromResult(binding);
        }
    }
}
