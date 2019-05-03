using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.ServiceFactory
{
    /// <summary>
    /// É executado em todas as solicitações e passa o contexto da function (por exemplo, solicitação HTTP e configuração do host) para um provedor de valor <see cref="ServiceFactoryValueProvider"/>
    /// </summary>
    public class ServiceFactoryBinding : IBinding
    {
        private readonly IServiceProvider _container;
        private readonly Type _type;

        public ServiceFactoryBinding(IServiceProvider container, Type type)
        {
            this._container = container;
            this._type = type;
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            Task<IValueProvider> valueProviderTask = Task.FromResult<IValueProvider>(new ServiceFactoryValueProvider(this._container, this._type));


            return valueProviderTask;
        }

        public bool FromAttribute => true;

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context) => null;

        public ParameterDescriptor ToParameterDescriptor() => new ParameterDescriptor();
    }

}
