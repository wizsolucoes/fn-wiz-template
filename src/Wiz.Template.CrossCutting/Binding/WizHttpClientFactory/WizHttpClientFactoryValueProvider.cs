using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Wiz.Template.CrossCutting.Binding.WizHttpClientFactory
{
    /// <summary>
    /// Cria instancia da classe <see cref="HttpClient"/> de acordo com as políticas pré-definidas pela classe <see cref="WizHttpClientOptions"/>.
    /// </summary>
    /// <remarks>
    /// Essa é parte fundamental em que uma HttpClient é criada e atribuída a algumas políticas, inclusive se já existe um access_token no context ele é propagado para outros serviços internos, seguindo assim nossa governança.
    /// </remarks>
    public class WizHttpClientFactoryValueProvider : IValueProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private static readonly string _projectName = Environment.GetEnvironmentVariable("wiz:project:name", EnvironmentVariableTarget.Process);


        private const string BEARER_PREFIX = "Bearer ";
        private HttpRequest _request;
        private WizHttpClientOptions _option;

        public WizHttpClientFactoryValueProvider(WizHttpClientOptions option, HttpRequest request, IHttpClientFactory httpClientFactory)
        {
            _request = request;
            _httpClientFactory = httpClientFactory;
            _option = option;
        }

        public async Task<object> GetValueAsync()
        {
            HttpClient client = null;

            switch (_option)
            {
                case WizHttpClientOptions.WizCross:
                    client = _httpClientFactory.CreateClient("WizCross");

                    //Agora ainda não esta pronto o projeto de Api Gateway da Wiz Cross. Quando existir alterar esse codigo;
                    //client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("wiz:cross:gateway:url"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
                    client.DefaultRequestHeaders.UserAgent.ParseAdd($"{_projectName}_{_request.Headers["User-Agent"].ToString()}");

                    string token = _request.Headers["Authorization"].ToString().Substring(BEARER_PREFIX.Length);

                    if (string.IsNullOrWhiteSpace(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(BEARER_PREFIX, token);
                    }

                    break;
                case WizHttpClientOptions.Outro:
                    client = _httpClientFactory.CreateClient("Outro");

                    client.DefaultRequestHeaders.UserAgent.ParseAdd($"{_projectName}_{_request.Headers["User-Agent"].ToString()}");

                    break;
            }

            return client;
        }

        public Type Type => typeof(HttpClient);

        public string ToInvokeString() => string.Empty;
    }
}
