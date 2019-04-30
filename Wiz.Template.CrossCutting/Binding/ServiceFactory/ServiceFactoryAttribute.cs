using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiz.Template.CrossCutting.Binding.ServiceFactory
{
    /// <summary>
    /// Atributo customizado para poder acessar um serviço injetado pela classe <see cref="ServiceFactoryExtensions"/> dentro da definição da function.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class ServiceFactoryAttribute : System.Attribute
    {
    }
}
