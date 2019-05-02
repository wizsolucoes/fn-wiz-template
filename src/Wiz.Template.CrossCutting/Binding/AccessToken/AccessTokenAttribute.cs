using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiz.Template.CrossCutting.Binding.AccessToken
{
    /// <summary>
    /// Atributo customizado para poder acessar um objeto do tipo <see cref="ClaimsPrincipal"/> dentro da definição da function.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class AccessTokenAttribute : System.Attribute
    {
    }
}
