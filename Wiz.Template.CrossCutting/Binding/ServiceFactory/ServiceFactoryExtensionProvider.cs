using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiz.Template.CrossCutting.Binding.ServiceFactory
{
    /// <summary>
    /// Wires up the attribute to the custom binding.
    /// </summary>
    [Extension("ServiceFactory")]
    public class ServiceFactoryExtensionProvider : IExtensionConfigProvider
    {
        private readonly IServiceProvider _container;

        public ServiceFactoryExtensionProvider(IServiceProvider container)
        {
            this._container = container;
        }


        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<ServiceFactoryAttribute>().Bind(new ServiceFactoryBindingProvider(this._container));
        }
    }

}
