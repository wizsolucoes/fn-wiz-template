using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Description;


namespace Wiz.Template.CrossCutting.Binding.AccessToken
{
    /// <summary>
    /// Wires up the attribute to the custom binding.
    /// </summary>
    [Extension("AccessToken")]
    public class AccessTokenExtensionProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            // Creates a rule that links the attribute to the binding
            var provider = new AccessTokenBindingProvider();
            var rule = context.AddBindingRule<AccessTokenAttribute>().Bind(provider);
        }
    }
}
