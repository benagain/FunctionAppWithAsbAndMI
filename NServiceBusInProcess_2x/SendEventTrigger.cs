using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System;

namespace NServiceBusInProcess_2x
{
    public class SendEventTrigger
    {
        private readonly IFunctionEndpoint endpoint;

        public SendEventTrigger(IFunctionEndpoint endpoint) => this.endpoint = endpoint;

        [FunctionName("SendEventTrigger")]
        public void Run([HttpTrigger] HttpRequest req, ExecutionContext executionContext, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var options = new SendOptions();
            options.RouteToThisEndpoint();
            endpoint.Send(new SampleMessage(), options, executionContext, log);
        }
    }
}
