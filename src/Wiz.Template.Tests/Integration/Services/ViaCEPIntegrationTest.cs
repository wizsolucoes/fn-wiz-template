using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wiz.Template.Domain.Models;
using Wiz.Template.Infra.Services;
using Xunit;

namespace Wiz.Template.Tests.Integration.Services
{
    public class ViaCEPIntegrationTest
    {
        public ViaCEPIntegrationTest()
        {
            Environment.SetEnvironmentVariable("API:ViaCEP", "https://viacep.com.br/ws");
        }

        [Fact]
        public async Task GetByCEPAsync_ReturnViaCEPModelTestAsync()
        {
            var cep = "68901111";
            var viaCEPservice = await new ViaCEPService().GetByCEPAsync(cep);

            var serviceResult = Assert.IsType<ViaCEP>(viaCEPservice);

            Assert.NotNull(serviceResult);
            Assert.NotNull(serviceResult.CEP);
        }
    }
}
