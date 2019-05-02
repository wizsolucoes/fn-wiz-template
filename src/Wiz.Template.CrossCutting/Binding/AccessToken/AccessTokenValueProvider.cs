using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.AccessToken
{
    /// <summary>
    /// Cria uma instância do tipo <see cref="ClaimsPrincipal"/> para o cabeçalho fornecido através do campo Authorization e valores de configuração.
    /// </summary>
    /// <remarks>
    /// É aqui que a autenticação real acontece - substitua esse código para implementar uma solução de autenticação diferente.
    /// </remarks>
    public class AccessTokenValueProvider : IValueProvider
    {
        private readonly IConfigurationManager<OpenIdConnectConfiguration> _configurationManager;

        private const string AUTH_HEADER_NAME = "Authorization";
        private const string BEARER_PREFIX = "Bearer ";
        private HttpRequest _request;
        private readonly string _audience;
        private readonly string _issuer;

        public AccessTokenValueProvider(HttpRequest request, string audience, string issuer)
        {
            _request = request;
            _audience = audience;
            _issuer = issuer;

            HttpDocumentRetriever documentRetriever = new HttpDocumentRetriever();
            documentRetriever.RequireHttps = issuer.StartsWith("https://");

            _configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                $"{issuer}/.well-known/openid-configuration",
                new OpenIdConnectConfigurationRetriever(),
                documentRetriever
            );
        }

        public async Task<object> GetValueAsync()
        {
            // Get the token from the header
            if (_request.Headers.ContainsKey(AUTH_HEADER_NAME) &&
               _request.Headers[AUTH_HEADER_NAME].ToString().StartsWith(BEARER_PREFIX))
            {
                var token = _request.Headers["Authorization"].ToString().Substring(BEARER_PREFIX.Length);
                OpenIdConnectConfiguration config = await _configurationManager.GetConfigurationAsync(CancellationToken.None);


                // Create the parameters
                TokenValidationParameters tokenParams = new TokenValidationParameters()
                {
                    RequireSignedTokens = true,
                    ValidAudience = _audience,
                    ValidateAudience = true,
                    ValidIssuer = _issuer,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKeys = config.SigningKeys
                };

                // Validate the token
                ClaimsPrincipal result = null;
                var tries = 0;

                while (result == null && tries <= 1)
                {
                    try
                    {
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        result = handler.ValidateToken(token, tokenParams, out var securityToken);

                    }
                    catch (SecurityTokenSignatureKeyNotFoundException ex)
                    {
                        _configurationManager.RequestRefresh();
                        tries++;
                    }
                    catch (SecurityTokenException ex)
                    {
                        return null;
                    }
                }


                return result;
            }
            else
            {
                throw new SecurityTokenException("No access token submitted.");
            }
        }

        public Type Type => typeof(ClaimsPrincipal);

        public string ToInvokeString() => string.Empty;
    }
}
