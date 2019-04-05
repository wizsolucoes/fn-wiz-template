using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wiz.Template.Domain.Models;

namespace Wiz.Template.Infra.Services
{
    public static class ViaCEPService
    {
        private static readonly string _api = Environment.GetEnvironmentVariable("API:ViaCEP", EnvironmentVariableTarget.Process);

        public static async Task<ViaCEP> GetByCEPAsync(string cep)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync($"{_api}/{cep}/json");
                var stringResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ViaCEP>(stringResponse);
            }
        }
    }
}
