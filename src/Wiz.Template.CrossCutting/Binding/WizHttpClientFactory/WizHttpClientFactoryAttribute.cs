using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiz.Template.CrossCutting.Binding.WizHttpClientFactory
{
    /// <summary>
    /// Atributo customizado para poder acessar uma instancia do HttpClient já configurado com as regras de resiliência definidas pelo Chapter Devz de acordo com as regras criadas dentro da classe <see cref="WizHttpClientFactoryExtensions"/> injetando na definição da function.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class WizHttpClientFactoryAttribute : System.Attribute
    {
        public WizHttpClientOptions Option { get; }

        public WizHttpClientFactoryAttribute(WizHttpClientOptions option)
        {
            Option = option;
        }
    }
}
