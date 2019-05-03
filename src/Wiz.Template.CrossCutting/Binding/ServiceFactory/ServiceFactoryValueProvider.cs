using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.ServiceFactory
{
    /// <summary>
    /// Cria uma instancia do serviço injetado pelo atributo <see cref="ServiceFactoryAttribute"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class ServiceFactoryValueProvider : IValueProvider
    {
        private readonly IServiceProvider _container;
        private readonly Type _type;

        public ServiceFactoryValueProvider(IServiceProvider container, Type type)
        {
            this._container = container;
            this._type = type;
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(this._container.GetService(_type));
        }

        public Type Type => this._type;

        public string ToInvokeString() => string.Empty;
    }

}
