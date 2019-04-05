using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Wiz.Template.Domain.Attribute;
using Xunit;

namespace Wiz.Template.Tests.Unit.Attribute
{
    public class ExceptionFilterAttributeTest
    {
        private readonly Mock<ILogger<ExceptionFilterAttribute>> _loggerMock;

        public ExceptionFilterAttributeTest()
        {
            _loggerMock = new Mock<ILogger<ExceptionFilterAttribute>>();
        }

        [Fact]
        public async Task ExceptionFilterAttribute_ExceptionTestAsync()
        {
            var mockKey = "29d342d1-8d08-44fc-a8bc-2ac3e25af903";
            Environment.SetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", mockKey);

            var exceptionFilter = new ExceptionFilterAttribute();

            var exceptionContext = new FunctionExceptionContext(
                functionInstanceId: Guid.NewGuid(),
                functionName: "FunctionMock",
                logger: _loggerMock.Object,
                exceptionDispatchInfo: ExceptionDispatchInfo.Capture(new Exception("MockException")),
                properties: new Dictionary<string, object>());

            await exceptionFilter.OnExceptionAsync(exceptionContext, new CancellationToken());

            Assert.NotNull(exceptionFilter);
        }
    }
}
