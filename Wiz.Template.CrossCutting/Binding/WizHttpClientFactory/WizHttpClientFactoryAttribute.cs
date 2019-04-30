using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiz.Template.CrossCutting.Binding.WizHttpClientFactory
{
    /// <summary>
    /// A custom attribute that lets you pass a <see cref="ClaimsPrincipal"/> into an function definition.
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
