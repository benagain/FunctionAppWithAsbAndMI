using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using NServiceBus;

[assembly: FunctionsStartup(typeof(Startup))]
[assembly: NServiceBusTriggerFunction(Startup.EndpointName)]

internal class Startup : FunctionsStartup
{
    public const string EndpointName = "MyQueue";

    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.UseNServiceBus(() => new ServiceBusTriggeredEndpointConfiguration(EndpointName, "AzureWebJobsServiceBus"));
    }
}