using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiz.Template.CrossCutting.Binding.AccessToken
{
    /// <summary>
    /// Uma chamada para carregar a Bind <see cref="AccessTokenBinding"/> personalizada quando o host do Azure Functions é inicializado.
    /// </summary>
    public static class AccessTokenExtensions
    {
        public static IWebJobsBuilder AddAccessTokenBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<AccessTokenExtensionProvider>();
            return builder;
        }
    }

}
