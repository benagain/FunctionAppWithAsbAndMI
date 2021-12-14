using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WebJobsServiceBus_520;

public static class Function1
{
    [FunctionName("Function1")]
    public static void Run([ServiceBusTrigger("myqueue", Connection = "AzureWebJobsServiceBus")] string myQueueItem, ILogger log)
    {
        log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
    }
}