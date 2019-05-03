using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Description;


namespace Wiz.Template.CrossCutting.Binding.AccessToken
{
    /// <summary>
    /// Cria um atributo para fazer a injeção de dependência.
    /// </summary>
    [Extension("AccessToken")]
    public class AccessTokenExtensionProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var provider = new AccessTokenBindingProvider();
            var rule = context.AddBindingRule<AccessTokenAttribute>().Bind(provider);
        }
    }
}
