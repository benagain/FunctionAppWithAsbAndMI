using Microsoft.Extensions.Logging;
using NServiceBus;
using System.Threading.Tasks;

namespace NServiceBusInProcess_2x
{
    public class SampleMessageHandler : IHandleMessages<SampleMessage>
    {
        private readonly ILogger<SampleMessageHandler> logger;

        public SampleMessageHandler(ILogger<SampleMessageHandler> logger)
            => this.logger = logger;

        public Task Handle(SampleMessage message, IMessageHandlerContext context)
        {
            logger.LogInformation("Received SampleMessage");
            return Task.CompletedTask;
        }
    }
}
