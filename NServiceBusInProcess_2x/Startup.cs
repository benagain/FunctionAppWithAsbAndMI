using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using NServiceBus;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
[assembly: NServiceBusTriggerFunction(Startup.EndpointName)]

internal class Startup : FunctionsStartup
{
    public const string EndpointName = "MyQueue";

    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.UseNServiceBus(hostConfig =>
        {
            var epConfig = new ServiceBusTriggeredEndpointConfiguration(EndpointName);

            var serviceBusFullyQualifiedName = hostConfig[$"AzureWebJobsServiceBus:fullyQualifiedNamespace"]
                ?? throw new Exception(
                    $"Azure Service Bus connection string namespace has not been configured. " +
                    $"Specify a connection string through an IConfiguration property named {{AzureWebJobsServiceBus__fullyQualifiedNamespace}}.");

            epConfig.Transport.ConnectionString(serviceBusFullyQualifiedName);
            epConfig.Transport.CustomTokenCredential(new DefaultAzureCredential());

            return epConfig;
        });
    }
}